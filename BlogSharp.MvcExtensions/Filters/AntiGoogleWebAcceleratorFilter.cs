namespace BlogSharp.MvcExtensions.Filters
{
	using System.Web.Mvc;

	#region castle license

	// Copyright 2004-2008 Castle Project - http://www.castleproject.org/
	// 
	// Licensed under the Apache License, Version 2.0 (the "License");
	// you may not use this file except in compliance with the License.
	// You may obtain a copy of the License at
	// 
	//     http://www.apache.org/licenses/LICENSE-2.0
	// 
	// Unless required by applicable law or agreed to in writing, software
	// distributed under the License is distributed on an "AS IS" BASIS,
	// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	// See the License for the specific language governing permissions and
	// limitations under the License.

	#endregion

	public class AntiGoogleWebAcceleratorFilter : ActionFilterAttribute
	{
		/// <summary>
		/// Implementors should perform they filter logic and
		/// return <c>true</c> if the action should be processed.
		/// Modified from castle/monorail project for Mvc
		/// </summary>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (filterContext.HttpContext.Request.Headers["HTTP_X_MOZ"].Equals("prefetch"))
			{
				filterContext.HttpContext.Response.StatusCode = 403;
				filterContext.Result = new EmptyResult();
			}
			else
				base.OnActionExecuting(filterContext);
		}
	}
}