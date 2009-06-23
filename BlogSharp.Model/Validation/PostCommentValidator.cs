// <copyright file="PostCommentValidator.cs" company="BlogSharp">
// Apache Licence 2.0 
// </copyright>
// <author>Gonzalo Brusella</author>
// <email>gonzalo@brusella.com.ar</email>
// <date>2009-02-21</date>

namespace BlogSharp.Model.Validation
{
    using FluentValidation;
    using Rules;

    /// <summary>
    /// A validator for the <see cref="PostComment"/> Class.
    /// </summary>
    public class PostCommentValidator : ValidatorBase<PostComment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostCommentValidator" /> class. 
        /// </summary>
        public PostCommentValidator()
        {
            this.RuleFor(x => x.Comment).NotEmpty();

            this.RuleFor(x => x.Commenter).NotNull().When(x => string.IsNullOrEmpty(x.Email) && string.IsNullOrEmpty(x.Name) && string.IsNullOrEmpty(x.Web));

            //this.RuleFor(x => x.Name).NotEmpty().When(x => x.Commenter.Equals(null));
            //this.RuleFor(x => x.Email).NotEmpty().And.EmailAddress().When(x => x.Commenter.Equals(null));
            //this.RuleFor(x => x.Web).NotEmpty().And.Url().When(x => !string.IsNullOrEmpty(x.Web) && x.Commenter.Equals(null));
        }
    }
}