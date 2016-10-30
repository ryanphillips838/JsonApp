using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Windows;

namespace JsonApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Post[] posts;
        private User[] users;
        private Album[] albums;
        private Photo[] photos;
        private Comment[] comments;
        private Todo[] todos;

        public MainWindow()
        {
            InitializeComponent();
            buttonGet_Click(null,null);
        }
        
        private void buttonGet_Click(object sender, RoutedEventArgs e)
        {
            var url = @"https://jsonplaceholder.typicode.com";
            var client = new WebClient();
            var result = client.DownloadString($"{url}/posts");
            posts = JsonConvert.DeserializeObject<Post[]>(result);
            label1.Content = $"{posts.Length} Posts available";

            result = client.DownloadString($"{url}/users");
            users = JsonConvert.DeserializeObject<User[]>(result);
            textBox2.Text = $"Number of users: {users.Length}\n";

            result = client.DownloadString($"{url}/albums");
            albums = JsonConvert.DeserializeObject<Album[]>(result);
            textBox2.AppendText($"albums: {albums.Length}\r\n");

            result = client.DownloadString($"{url}/photos");
            photos = JsonConvert.DeserializeObject<Photo[]>(result);
            textBox2.AppendText($"photos: {photos.Length}\r\n");

            result = client.DownloadString($"{url}/comments");
            comments = JsonConvert.DeserializeObject<Comment[]>(result);
            textBox2.AppendText($"comments: {comments.Length}\r\n");

            result = client.DownloadString($"{url}/todos");
            todos = JsonConvert.DeserializeObject<Todo[]>(result);
            textBox2.AppendText($"todos: {todos.Length}");
        }

        private void buttonSet_Click(object sender, RoutedEventArgs e)
        {
            Post post;
            try
            {
                post = posts[int.Parse(textBoxPostNumber.Text) - 1];
            }
            catch
            {
                textBox1.Clear();
                textBox1.AppendText("Could not load post");
                return;
            }
            textBox1.Clear();
            textBox1.AppendText($"{post.title}\r\n\r\n{post.body}\r\n\r\n----------\r\n\r\n");

            var user = (from u in users
                        where u.id == post.userId
                        select u).First();

            textBox2.Clear();
            textBox2.AppendText($"@{user.username} ({user.name}) wrote\n\r\n");

            var query = from com in comments
                        where com.postId == post.id
                        select com;

            if (query.Count() == 0) return;

            foreach(var comment in query)
            {
                textBox1.AppendText($"@{comment.email} commented:\r\n{comment.name}\r\n\r\n{comment.body}\r\n--\r\n\r\n");
            }
        }
    }
}
