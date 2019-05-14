﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCEventCalendar
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ClassroomAllocationSystemEntities1 : DbContext
    {
        public ClassroomAllocationSystemEntities1()
            : base("name=ClassroomAllocationSystemEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminDetail> AdminDetails { get; set; }
        public virtual DbSet<BookRoom> BookRooms { get; set; }
        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<UserQuestionDetail> UserQuestionDetails { get; set; }
        public virtual DbSet<UserRegistrationDetail> UserRegistrationDetails { get; set; }
        public virtual DbSet<ClassRoomDetail> ClassRoomDetails { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
    
        public virtual ObjectResult<getAllRooms_Result> getAllRooms()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAllRooms_Result>("getAllRooms");
        }
    
        public virtual ObjectResult<GetFeedback_Result> GetFeedback()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFeedback_Result>("GetFeedback");
        }
    
        public virtual ObjectResult<GetFeedbacks_Result> GetFeedbacks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetFeedbacks_Result>("GetFeedbacks");
        }
    
        public virtual ObjectResult<Nullable<int>> GetResource(Nullable<int> quantity1, Nullable<int> quantity2, Nullable<int> quantity3)
        {
            var quantity1Parameter = quantity1.HasValue ?
                new ObjectParameter("quantity1", quantity1) :
                new ObjectParameter("quantity1", typeof(int));
    
            var quantity2Parameter = quantity2.HasValue ?
                new ObjectParameter("quantity2", quantity2) :
                new ObjectParameter("quantity2", typeof(int));
    
            var quantity3Parameter = quantity3.HasValue ?
                new ObjectParameter("quantity3", quantity3) :
                new ObjectParameter("quantity3", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetResource", quantity1Parameter, quantity2Parameter, quantity3Parameter);
        }
    
        public virtual ObjectResult<Nullable<int>> ValidateBookingClassroom(Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, Nullable<int> classroomId)
        {
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            var classroomIdParameter = classroomId.HasValue ?
                new ObjectParameter("ClassroomId", classroomId) :
                new ObjectParameter("ClassroomId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ValidateBookingClassroom", startDateParameter, endDateParameter, classroomIdParameter);
        }
    
        public virtual int InsertFeedback(Nullable<int> empid, string feedback, Nullable<System.DateTime> date)
        {
            var empidParameter = empid.HasValue ?
                new ObjectParameter("empid", empid) :
                new ObjectParameter("empid", typeof(int));
    
            var feedbackParameter = feedback != null ?
                new ObjectParameter("feedback", feedback) :
                new ObjectParameter("feedback", typeof(string));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertFeedback", empidParameter, feedbackParameter, dateParameter);
        }
    
        public virtual ObjectResult<getResourcesbyClassroom_Result1> getResourcesbyClassroom(Nullable<int> classroomid)
        {
            var classroomidParameter = classroomid.HasValue ?
                new ObjectParameter("classroomid", classroomid) :
                new ObjectParameter("classroomid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getResourcesbyClassroom_Result1>("getResourcesbyClassroom", classroomidParameter);
        }
    
        public virtual ObjectResult<classroomsAndResource_Result1> classroomsAndResource()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<classroomsAndResource_Result1>("classroomsAndResource");
        }
    
        public virtual ObjectResult<GetResourcebyName_Result> GetResourcebyName(Nullable<int> quantity1, Nullable<int> quantity2, Nullable<int> quantity3)
        {
            var quantity1Parameter = quantity1.HasValue ?
                new ObjectParameter("quantity1", quantity1) :
                new ObjectParameter("quantity1", typeof(int));
    
            var quantity2Parameter = quantity2.HasValue ?
                new ObjectParameter("quantity2", quantity2) :
                new ObjectParameter("quantity2", typeof(int));
    
            var quantity3Parameter = quantity3.HasValue ?
                new ObjectParameter("quantity3", quantity3) :
                new ObjectParameter("quantity3", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetResourcebyName_Result>("GetResourcebyName", quantity1Parameter, quantity2Parameter, quantity3Parameter);
        }
    }
}
