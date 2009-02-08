using System.Collections.Generic;
using System.Web.Mvc;
using BlogSharp.Core.Impl.Web;
using BlogSharp.Core.Services.Post;
using BlogSharp.Model;
using BlogSharp.Model.Validation;
using BlogSharp.Web.Code;
using FluentValidation;
using Spark.Web.Mvc;
using System;
using Microsoft.Web.Mvc;

namespace BlogSharp.Web.Controllers
{
	[HandleError]
	public class PostController : BlogSharpController
	{
		private readonly IPostService postService;

		public PostController(IPostService postService)
		{
			this.postService = postService;
		}

		public ActionResult List(int page)
		{
			var posts = postService.GetPostsByBlogPaged(CurrentBlog, 0,CurrentBlog.Configuration.PageSize);
			return View(posts);
		}

		public ActionResult ListByTag(string tagName,int page)
		{
			var tag = tagName;
			var posts = postService.GetPostsByTagPaged(CurrentBlog, tagName, 0, CurrentBlog.Configuration.PageSize);
			return View("PostByTagList", new {tag = tag, posts = posts});
		}
		
		public ActionResult Read(string friendlyTitle)
		{
			var post = postService.GetPostByFriendlyTitle(CurrentBlog, friendlyTitle);
			return View(post);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult AddComment(int postId, PostComment comment)
		{
			var post = postService.GetPostById(CurrentBlog, postId);
			comment.Post = post;
			comment.Date = DateTime.Now;
			try
			{
				postService.AddComment(comment);
			}
			catch(ValidationException vex)
			{
				this.ModelState.AddValidationExceptionToModel("comment",vex);
			}
			
			return View("Read", post);
		}
	}
}
