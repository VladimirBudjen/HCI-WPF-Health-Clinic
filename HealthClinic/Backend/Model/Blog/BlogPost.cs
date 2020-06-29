// File:    BlogPost.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class BlogPost

using Model.Accounts;
using System;
using System.Collections.Generic;

namespace Model.Blog
{
   public class BlogPost
   {
      private String name;
      
      private List<Comment> comment;
      
      public List<Comment> Comment
      {
         get
         {
            if (comment == null)
               comment = new List<Comment>();
            return comment;
         }
         set
         {
            RemoveAllComment();
            if (value != null)
            {
               foreach (Comment oComment in value)
                  AddComment(oComment);
            }
         }
      }
      
      public void AddComment(Comment newComment)
      {
         if (newComment == null)
            return;
         if (this.comment == null)
            this.comment = new System.Collections.Generic.List<Comment>();
         if (!this.comment.Contains(newComment))
            this.comment.Add(newComment);
      }
      
      public void RemoveComment(Comment oldComment)
      {
         if (oldComment == null)
            return;
         if (this.comment != null)
            if (this.comment.Contains(oldComment))
               this.comment.Remove(oldComment);
      }
      
      public void RemoveAllComment()
      {
         if (comment != null)
            comment.Clear();
      }

      private Model.Accounts.Physitian physitian;
      
      public Physitian Physitian
      {
         get
         {
            return physitian;
         }
         set
         {
            this.physitian = value;
         }
      }
   
   }
}