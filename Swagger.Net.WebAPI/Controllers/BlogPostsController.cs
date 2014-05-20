using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swagger.Net.WebApi.Models;

namespace Swagger.Net.WebApi.Controllers
{    
    public class BlogPostsController : ApiController
    {
        private List<BlogPost> blogPosts = new List<BlogPost>
        {
            new BlogPost
            {
                Id = 1,
                Title = "Post 1",
                Body = "Hello",
                Author = new Author {Email = "bob@myblog.com", Name = "Bob"}
            },
            new BlogPost
            {
                Id = 2,
                Title = "Post 2",
                Body =
                    "Lorem ipsum dolor sit amet, consectetur adipisici elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquid ex ea commodi consequat. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                Author = new Author {Email = "john@myblog.com", Name = "John"}
            }
        };

        // GET api/blogposts
        public IEnumerable<BlogPost> Get()
        {
            return blogPosts;
        }

        // GET api/blogposts/5
        public BlogPost Get(int id)
        {
            return blogPosts.First(x => x.Id == id);
        }

        // POST api/blogposts
        public void Post([FromBody]BlogPost blogPost)
        {
        }

        // PUT api/blogposts/5
        public void Put(int id, [FromBody]BlogPost blogPost)
        {
        }

        // DELETE api/blogposts/5
        public void Delete(int id)
        {
        }
    }
}
