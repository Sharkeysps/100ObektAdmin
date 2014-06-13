using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoObektaAdmin.Models
{
    public class CommentsModel
    {
        public List<CommentModel> Comments { get; set; }

        public CommentsModel()
        {
            this.Comments = new List<CommentModel>();
        }

        public void DeleteComment(int commentID)
        {
            using (var db = new SitesDB.SitesDBEntities())
            { 
                var comment=(from com in db.SiteComments 
                             where com.ID==commentID
                             select com).FirstOrDefault();
                if(comment!=null)
                {
                    db.SiteComments.Remove(comment);
                    db.SaveChanges();
                }
            }
        }

        public void FindComments(int siteId)
        {
            using (var db = new SitesDB.SitesDBEntities())
            {
                var comments = (from c in db.SiteComments
                                where c.SiteID == siteId
                                select c);

                foreach (var comment in comments)
                {
                    var commentModel = new CommentModel();
                    commentModel.Comment = comment.Comment;
                    commentModel.SiteID = comment.SiteID;
                    commentModel.UserName = comment.UserName;
                    commentModel.CommentId = comment.ID;
                    Comments.Add(commentModel);

                }

            }

        }
    }
}