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
			var posts = postService.GetPostsByBlogPaged(CurrentBlog, 0, CurrentBlog.Configuration.PageSize);
			return View(posts);
		}

		public ActionResult ListByTag(string tagName, int page)
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
		[ValidateAntiForgeryToken]
		public ActionResult AddComment(int postId, PostComment comment)
		{
			var post = postService.GetPostById(CurrentBlog, postId);
			comment.Post = post;
			comment.Date = DateTime.Now;
			using (var tranScope = new TransactionScope())
			{
				try
				{
					postService.AddComment(comment);
					tranScope.Complete();
				}
				catch (ValidationException vex)
				{
					Transaction.Current.Rollback();
					ModelState.AddValidationExceptionToModel("comment", vex);
				}
			}
			return View("Read", post);
		}
	}
}