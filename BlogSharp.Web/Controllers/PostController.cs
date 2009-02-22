namespace BlogSharp.Web.Controllers
{
	using System;
	using System.Transactions;
	using System.Web.Mvc;
	using Code;
	using Core.Services.Post;
	using Model;
	using Model.Validation;

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
			var posts = this.postService.GetPostsByBlogPaged(this.CurrentBlog, 0, this.CurrentBlog.Configuration.PageSize);
			return View(posts);
		}

		public ActionResult ListByTag(string tagName, int page)
		{
			var tag = tagName;
			var posts = this.postService.GetPostsByTagPaged(this.CurrentBlog, tagName, 0, this.CurrentBlog.Configuration.PageSize);
			return this.View("PostByTagList", new {tag = tag, posts = posts});
		}

		public ActionResult Read(string friendlyTitle)
		{
			var post = this.postService.GetPostByFriendlyTitle(this.CurrentBlog, friendlyTitle);
			return View(post);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		[ValidateAntiForgeryToken]
		public ActionResult AddComment(int postId, PostComment comment)
		{
			var post = this.postService.GetPostById(this.CurrentBlog, postId);
			comment.Post = post;
			comment.Date = DateTime.Now;
			using (var tranScope = new TransactionScope())
			{
				try
				{
					this.postService.AddComment(comment);
					tranScope.Complete();
				}
				catch (ValidationException vex)
				{
					Transaction.Current.Rollback();
					this.ModelState.AddValidationExceptionToModel("comment", vex);
				}
			}
			return View("Read", post);
		}
	}
}