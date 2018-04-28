using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IRSystemDataServer.Model.Database
{
    public partial class InfraredSystemContext : DbContext
    {
        public InfraredSystemContext()
           : base("name=DBModel")
        {
        }

        public virtual DbSet<AdminUser> AdminUser { get; set; }
        public virtual DbSet<AdminUserRole> AdminUserRole { get; set; }
        public virtual DbSet<Apointment> Apointment { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Camera> Camera { get; set; }
        public virtual DbSet<DoctorMachinery> DoctorMachinery { get; set; }
        public virtual DbSet<DoctorReportCategory> DoctorReportCategory { get; set; }
        public virtual DbSet<DoctorReportOption> DoctorReportOption { get; set; }
        public virtual DbSet<Gesture> Gesture { get; set; }
        public virtual DbSet<InfraredData> InfraredData { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Machinery> Machinery { get; set; }
        public virtual DbSet<Membership> Membership { get; set; }
        public virtual DbSet<MembershipType> MembershipType { get; set; }
        public virtual DbSet<NineAsk> NineAsk { get; set; }
        public virtual DbSet<NineAskQuestionnaire> NineAskQuestionnaire { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<Selection> Selection { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<User> User { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUser>().ToTable("admin_user");
            modelBuilder.Entity<AdminUser>().HasIndex(e => e.Account)
                    .HasName("account")
                    .IsUnique();

            modelBuilder.Entity<AdminUser>().Property(e => e.Id)
                   .HasColumnName("id")
                   .HasColumnType("bigint")
                   .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<AdminUser>().Property(e => e.Account)
                    .IsRequired()
                    .HasColumnName("account")
                    .HasMaxLength(100);

            modelBuilder.Entity<AdminUser>().Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<AdminUser>().Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("tinyint");

            modelBuilder.Entity<AdminUser>().Property(e => e.IsDisabled)
                    .HasColumnName("isDisabled")
                    .HasColumnType("tinyint");

            modelBuilder.Entity<AdminUser>().Property(e => e.ModifiedTime)
                    .HasColumnName("modifiedTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<AdminUser>().Property(e => e.Operator)
                    .HasColumnName("operator")
                    .HasMaxLength(255);

            modelBuilder.Entity<AdminUser>().Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

            modelBuilder.Entity<AdminUser>().Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnName("passwordSalt")
                    .HasMaxLength(255);

            modelBuilder.Entity<AdminUser>().Property(e => e.PhoneNum)
                    .IsRequired()
                    .HasColumnName("phoneNum")
                    .HasMaxLength(255);

            modelBuilder.Entity<AdminUser>().Property(e => e.RealName)
                    .HasColumnName("realName")
                    .HasMaxLength(45);


            modelBuilder.Entity<AdminUserRole>().ToTable("admin_user_role");
            modelBuilder.Entity<AdminUserRole>().HasIndex(e => e.AdminUserId)
                    .HasName("adminUserId");
            modelBuilder.Entity<AdminUserRole>().HasIndex(e => e.RoleId)
                   .HasName("roleId");

            modelBuilder.Entity<AdminUserRole>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<AdminUserRole>().Property(e => e.AdminUserId)
                    .HasColumnName("adminUserId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<AdminUserRole>().Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<AdminUserRole>().Property(e => e.ModifiedTime)
                    .HasColumnName("modifiedTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<AdminUserRole>().Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("bigint");


            modelBuilder.Entity<Apointment>().ToTable("apointment");
            modelBuilder.Entity<Apointment>().HasIndex(e => new { e.UserId, e.CreateTime, e.State, e.AdminUserId })
                    .HasName("userid");

            modelBuilder.Entity<Apointment>().Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Apointment>().Property(e => e.AdminUserId)
                    .HasColumnName("adminUserId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<Apointment>().Property(e => e.ApointmentTime)
                    .HasColumnName("apointmentTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Apointment>().Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Apointment>().Property(e => e.MachineryId)
                    .HasColumnName("machineryId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<Apointment>().Property(e => e.ModifiedTime)
                    .HasColumnName("modifiedTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Apointment>().Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("int");

            modelBuilder.Entity<Apointment>().Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("bigint");


            modelBuilder.Entity<Area>().ToTable("area");
            modelBuilder.Entity<Area>().HasIndex(e => e.Areaid)
                    .HasName("areaid");

            modelBuilder.Entity<Area>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Area>().Property(e => e.Areaid)
                    .HasColumnName("areaid")
                    .HasMaxLength(255);

            modelBuilder.Entity<Area>().Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(255);

            modelBuilder.Entity<Area>().Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Area>().Property(e => e.First)
                    .HasColumnName("first")
                    .HasMaxLength(255);

            modelBuilder.Entity<Area>().Property(e => e.Jianpin)
                    .HasColumnName("jianpin")
                    .HasMaxLength(255);

            modelBuilder.Entity<Area>().Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal");

            modelBuilder.Entity<Area>().Property(e => e.Lel)
                    .HasColumnName("lel")
                    .HasMaxLength(255);

            modelBuilder.Entity<Area>().Property(e => e.Lng)
                    .HasColumnName("lng")
                    .HasColumnType("decimal");

            modelBuilder.Entity<Area>().Property(e => e.MergerName)
                    .HasColumnName("mergerName")
                    .HasMaxLength(255);

            modelBuilder.Entity<Area>().Property(e => e.Mergershortname)
                    .HasColumnName("mergershortname")
                    .HasMaxLength(255);

            modelBuilder.Entity<Area>().Property(e => e.ModifiedTime)
                    .HasColumnName("modifiedTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Area>().Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

            modelBuilder.Entity<Area>().Property(e => e.ParentId)
                    .HasColumnName("parentId")
                    .HasMaxLength(255);

            modelBuilder.Entity<Area>().Property(e => e.Pinyin)
                    .HasColumnName("pinyin")
                    .HasMaxLength(255);

            modelBuilder.Entity<Area>().Property(e => e.Short)
                    .HasColumnName("short")
                    .HasMaxLength(255);

            modelBuilder.Entity<Area>().Property(e => e.Zipcode)
                    .HasColumnName("zipcode")
                    .HasMaxLength(255);

            modelBuilder.Entity<Camera>().ToTable("camera");


            modelBuilder.Entity<Camera>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Camera>().Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Camera>().Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Camera>().Property(e => e.Doctor)
                    .HasColumnName("doctor")
                    .HasMaxLength(255);

            modelBuilder.Entity<Camera>().Property(e => e.FaceFilePath)
                    .HasColumnName("faceFilePath")
                    .HasMaxLength(255);

            modelBuilder.Entity<Camera>().Property(e => e.HandBackFilePath)
                    .HasColumnName("handBackFilePath")
                    .HasMaxLength(255);

            modelBuilder.Entity<Camera>().Property(e => e.HandFrontFilePath)
                    .HasColumnName("handFrontFilePath")
                    .HasMaxLength(255);

            modelBuilder.Entity<Camera>().Property(e => e.IdCard)
                    .HasColumnName("idCard")
                    .HasMaxLength(255);

            modelBuilder.Entity<Camera>().Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("tinyint")
                    ;

            modelBuilder.Entity<Camera>().Property(e => e.IsMale)
                    .HasColumnName("isMale")
                    .HasColumnType("tinyint")
                    ;

            modelBuilder.Entity<Camera>().Property(e => e.ModifiedTime)
                    .HasColumnName("modifiedTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Camera>().Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

            modelBuilder.Entity<Camera>().Property(e => e.Operator)
                    .HasColumnName("operator")
                    .HasMaxLength(255);

            modelBuilder.Entity<Camera>().Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(255);

            modelBuilder.Entity<Camera>().Property(e => e.TongueFilePath)
                    .HasColumnName("tongueFilePath")
                    .HasMaxLength(255);

            modelBuilder.Entity<Camera>().Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<DoctorMachinery>().ToTable("doctor_machinery");

            modelBuilder.Entity<DoctorMachinery>().HasIndex(e => e.DoctorId)
                    .HasName("doctorId");

            modelBuilder.Entity<DoctorMachinery>().HasIndex(e => e.MachineId)
                    .HasName("machineryid");

            modelBuilder.Entity<DoctorMachinery>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<DoctorMachinery>().Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<DoctorMachinery>().Property(e => e.DoctorId)
                    .HasColumnName("doctorId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<DoctorMachinery>().Property(e => e.DoctorName)
                    .HasColumnName("doctorName")
                    .HasMaxLength(255);

            modelBuilder.Entity<DoctorMachinery>().Property(e => e.DoctorPhone)
                    .HasColumnName("doctorPhone")
                    .HasMaxLength(255);

            modelBuilder.Entity<DoctorMachinery>().Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("tinyint")
                    ;

            modelBuilder.Entity<DoctorMachinery>().Property(e => e.IsDisabled)
                    .HasColumnName("isDisabled")
                    .HasColumnType("tinyint")
                    ;

            modelBuilder.Entity<DoctorMachinery>().Property(e => e.MachineAddress)
                    .HasColumnName("machineAddress")
                    .HasMaxLength(255);

            modelBuilder.Entity<DoctorMachinery>().Property(e => e.MachineCode)
                    .HasColumnName("machineCode")
                    .HasMaxLength(255);

            modelBuilder.Entity<DoctorMachinery>().Property(e => e.MachineId)
                    .HasColumnName("machineId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<DoctorMachinery>().Property(e => e.ModifiedTime)
                    .HasColumnName("modifiedTime")
                    .HasColumnType("datetime");


            modelBuilder.Entity<DoctorReportCategory>().ToTable("doctorReportCategory");

            modelBuilder.Entity<DoctorReportCategory>().HasIndex(e => e.Parentid)
                    .HasName("ix_docReportCategory_parentId");

            modelBuilder.Entity<DoctorReportCategory>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<DoctorReportCategory>().Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasColumnType("tinyint");

            modelBuilder.Entity<DoctorReportCategory>().Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int");

            modelBuilder.Entity<DoctorReportCategory>().Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200);

            modelBuilder.Entity<DoctorReportCategory>().Property(e => e.Parentid)
                    .HasColumnName("parentid")
                    .HasColumnType("bigint")
                    ;


            modelBuilder.Entity<DoctorReportOption>().ToTable("doctorReportOption");

            modelBuilder.Entity<DoctorReportOption>().HasIndex(e => e.CategoryId)
                        .HasName("ix_docReportOption_categoryId");

            modelBuilder.Entity<DoctorReportOption>().Property(e => e.Id)
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<DoctorReportOption>().Property(e => e.CategoryId)
                                .HasColumnName("categoryId")
                                .HasColumnType("bigint");

            modelBuilder.Entity<DoctorReportOption>().Property(e => e.IsActive)
                                .HasColumnName("isActive")
                                .HasColumnType("tinyint");

            modelBuilder.Entity<DoctorReportOption>().Property(e => e.Name)
                                .HasColumnName("name")
                                .HasMaxLength(200);

            modelBuilder.Entity<DoctorReportOption>().Property(e => e.Value)
                                .HasColumnName("value")
                                .HasMaxLength(200);

            modelBuilder.Entity<Gesture>().ToTable("gesture");

            modelBuilder.Entity<Gesture>().HasIndex(e => new { e.IsActive, e.Gender })
                    .HasName("idx_gesture_isActive");

            modelBuilder.Entity<Gesture>().Property(e => e.Id)
                            .HasColumnName("id")
                            .HasColumnType("int")
                            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Gesture>().Property(e => e.CreateTime)
                            .HasColumnName("createTime")
                            .HasColumnType("datetime");

            modelBuilder.Entity<Gesture>().Property(e => e.Description)
                            .HasColumnName("description")
                            .HasMaxLength(45);

            modelBuilder.Entity<Gesture>().Property(e => e.Gender)
                            .HasColumnName("gender")
                            .HasColumnType("tinyint");

            modelBuilder.Entity<Gesture>().Property(e => e.Gesturecol)
                            .HasColumnName("gesturecol")
                            .HasMaxLength(45);

            modelBuilder.Entity<Gesture>().Property(e => e.IsActive)
                            .HasColumnName("isActive")
                            .HasColumnType("tinyint");

            modelBuilder.Entity<Gesture>().Property(e => e.ModifiedTime)
                            .HasColumnName("modifiedTime")
                            .HasColumnType("datetime");

            modelBuilder.Entity<Gesture>().Property(e => e.Name)
                            .HasColumnName("name")
                            .HasMaxLength(45);

            modelBuilder.Entity<InfraredData>().ToTable("infraredData");

            modelBuilder.Entity<InfraredData>().HasIndex(e => new
            {
                e.ApointmentId,
                e.UserId
            })
                    .HasName("idx_infraredData_userId");

            modelBuilder.Entity<InfraredData>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<InfraredData>().Property(e => e.AdminUserId)
                            .HasColumnName("adminUserId")
                            .HasColumnType("int");

            modelBuilder.Entity<InfraredData>().Property(e => e.ApointmentId)
                            .HasColumnName("apointmentId")
                            .HasColumnType("bigint");

            modelBuilder.Entity<InfraredData>().Property(e => e.CreateTime)
                            .HasColumnName("createTime")
                            .HasColumnType("datetime");

            modelBuilder.Entity<InfraredData>().Property(e => e.Data)
                            .HasColumnName("data")
                            .HasColumnType("mediumblob");

            modelBuilder.Entity<InfraredData>().Property(e => e.DataFile)
                            .HasColumnName("dataFile")
                            .HasMaxLength(300);

            modelBuilder.Entity<InfraredData>().Property(e => e.GestureId)
                            .HasColumnName("gestureId")
                            .HasColumnType("int");

            modelBuilder.Entity<InfraredData>().Property(e => e.Height)
                            .HasColumnName("height")
                            .HasColumnType("int");

            modelBuilder.Entity<InfraredData>().Property(e => e.ModifiedTime)
                            .HasColumnName("modifiedTime")
                            .HasColumnType("datetime");

            modelBuilder.Entity<InfraredData>().Property(e => e.UserId)
                            .HasColumnName("userId")
                            .HasColumnType("int");

            modelBuilder.Entity<InfraredData>().Property(e => e.Width)
                            .HasColumnName("width")
                            .HasColumnType("int");

            modelBuilder.Entity<InfraredData>().Property(e => e.WindowStart)
                            .HasColumnName("windowStart")
                            .HasColumnType("int");

            modelBuilder.Entity<InfraredData>().Property(e => e.WindowWidth)
                            .HasColumnName("windowWidth")
                            .HasColumnType("int");

            modelBuilder.Entity<Invoice>().ToTable("invoice");

            modelBuilder.Entity<Invoice>().HasIndex(e => new
            {
                e.IsPaid,
                e.AdminUserId
            })
                    .HasName("ix_invoice_ispaid_adminUserid");

            modelBuilder.Entity<Invoice>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Invoice>().Property(e => e.AdminUserId)
                    .HasColumnName("adminUserId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<Invoice>().Property(e => e.IsPaid)
                    .HasColumnName("isPaid")
                    .HasColumnType("tinyint");

            modelBuilder.Entity<Invoice>().Property(e => e.MachineryId)
                    .HasColumnName("machineryId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<Invoice>().Property(e => e.MembershipId)
                    .HasColumnName("membershipId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<Invoice>().Property(e => e.PayAccount)
                    .HasColumnName("payAccount")
                    .HasMaxLength(100);

            modelBuilder.Entity<Invoice>().Property(e => e.PayType)
                    .HasColumnName("payType")
                    .HasMaxLength(45);

            modelBuilder.Entity<Invoice>().Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal");


            modelBuilder.Entity<Machinery>().ToTable("machinery");

            modelBuilder.Entity<Machinery>().HasIndex(e => e.Areaid)
                    .HasName("areaid");

            modelBuilder.Entity<Machinery>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Machinery>().Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255);

            modelBuilder.Entity<Machinery>().Property(e => e.Areaid)
                    .HasColumnName("areaid")
                    .HasMaxLength(255);

            modelBuilder.Entity<Machinery>().Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Machinery>().Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("tinyint")
                    ;

            modelBuilder.Entity<Machinery>().Property(e => e.Machinecode)
                    .IsRequired()
                    .HasColumnName("machinecode")
                    .HasMaxLength(255);

            modelBuilder.Entity<Machinery>().Property(e => e.Machinefile)
                    .IsRequired()
                    .HasColumnName("machinefile")
                    .HasMaxLength(255);

            modelBuilder.Entity<Machinery>().Property(e => e.ModifiedTime)
                    .HasColumnName("modifiedTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Machinery>().Property(e => e.ProductType)
                    .HasColumnName("productType")
                    .HasMaxLength(255);

            modelBuilder.Entity<Membership>().ToTable("membership");

            modelBuilder.Entity<Membership>().HasIndex(e => new { e.Userid, e.IsValid, e.ExpireTime })
                    .HasName("ix_userid_isvalid");

            modelBuilder.Entity<Membership>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Membership>().Property(e => e.BeginTime)
                    .HasColumnName("beginTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Membership>().Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Membership>().Property(e => e.ExpireTime)
                    .HasColumnName("expireTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Membership>().Property(e => e.IsValid)
                    .HasColumnName("isValid")
                    .HasColumnType("tinyint");

            modelBuilder.Entity<Membership>().Property(e => e.MachineryId)
                    .HasColumnName("machineryId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<Membership>().Property(e => e.OperatorId)
                    .HasColumnName("operatorId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<Membership>().Property(e => e.RemainCheck)
                    .HasColumnName("remainCheck")
                    .HasColumnType("int");

            modelBuilder.Entity<Membership>().Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int");

            modelBuilder.Entity<Membership>().Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("bigint");

            modelBuilder.Entity<MembershipType>().ToTable("membershipType");

            modelBuilder.Entity<MembershipType>().Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<MembershipType>().Property(e => e.DefaultCheckupTimes)
                                .HasColumnName("defaultCheckupTimes")
                                .HasColumnType("int");

            modelBuilder.Entity<MembershipType>().Property(e => e.DurationInDays)
                                .HasColumnName("durationInDays")
                                .HasColumnType("int");

            modelBuilder.Entity<MembershipType>().Property(e => e.Name)
                                .HasColumnName("name")
                                .HasMaxLength(200);

            modelBuilder.Entity<MembershipType>().Property(e => e.Price)
                                .HasColumnName("price")
                                .HasColumnType("decimal");

            modelBuilder.Entity<NineAsk>().ToTable("nine_ask");

            modelBuilder.Entity<NineAsk>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<NineAsk>().Property(e => e.AId)
                    .HasColumnName("aId")
                    .HasColumnType("int");

            modelBuilder.Entity<NineAsk>().Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

            modelBuilder.Entity<NineAskQuestionnaire>().ToTable("nine_ask_questionnaire");

            modelBuilder.Entity<NineAskQuestionnaire>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<NineAskQuestionnaire>().Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("datetime");

            modelBuilder.Entity<NineAskQuestionnaire>().Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<NineAskQuestionnaire>().Property(e => e.IdCard)
                    .HasColumnName("idCard")
                    .HasMaxLength(255);

            modelBuilder.Entity<NineAskQuestionnaire>().Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("tinyint")
                    ;

            modelBuilder.Entity<NineAskQuestionnaire>().Property(e => e.IsMale)
                    .HasColumnName("isMale")
                    .HasColumnType("tinyint");

            modelBuilder.Entity<NineAskQuestionnaire>().Property(e => e.ModifiedTime)
                    .HasColumnName("modifiedTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<NineAskQuestionnaire>().Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255);

            modelBuilder.Entity<NineAskQuestionnaire>().Property(e => e.NineAsk)
                    .HasColumnName("nineAsk")
                    .HasMaxLength(255);

            modelBuilder.Entity<NineAskQuestionnaire>().Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(255);

            modelBuilder.Entity<NineAskQuestionnaire>().Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<Permission>().ToTable("permission");

            modelBuilder.Entity<Permission>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Permission>().Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Permission>().Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

            modelBuilder.Entity<Permission>().Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("tinyint")
                    ;

            modelBuilder.Entity<Permission>().Property(e => e.ModifiedTime)
                    .HasColumnName("modifiedTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Permission>().Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(255);

            modelBuilder.Entity<Role>().ToTable("role");

            modelBuilder.Entity<Role>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Role>().Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Role>().Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

            modelBuilder.Entity<Role>().Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("tinyint")
                    ;

            modelBuilder.Entity<Role>().Property(e => e.ModifiedTime)
                    .HasColumnName("modifiedTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Role>().Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

            modelBuilder.Entity<RolePermission>().ToTable("role_permission");

            modelBuilder.Entity<RolePermission>().HasIndex(e => e.PermissionId)
                    .HasName("permissionId");

            modelBuilder.Entity<RolePermission>().HasIndex(e => e.RoleId)
                    .HasName("roleId");

            modelBuilder.Entity<RolePermission>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<RolePermission>().Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<RolePermission>().Property(e => e.ModifiedTime)
                    .HasColumnName("modifiedTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<RolePermission>().Property(e => e.PermissionId)
                    .HasColumnName("permissionId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<RolePermission>().Property(e => e.RoleId)
                    .HasColumnName("roleId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<Selection>().ToTable("selection");

            modelBuilder.Entity<Selection>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Selection>().Property(e => e.Bottom)
                    .HasColumnName("bottom")
                    .HasColumnType("int");

            modelBuilder.Entity<Selection>().Property(e => e.InfraredDataId)
                    .HasColumnName("infraredDataId")
                    .HasColumnType("bigint");

            modelBuilder.Entity<Selection>().Property(e => e.Left)
                    .HasColumnName("left")
                    .HasColumnType("int");

            modelBuilder.Entity<Selection>().Property(e => e.Right)
                    .HasColumnName("right")
                    .HasColumnType("int");

            modelBuilder.Entity<Selection>().Property(e => e.Shape)
                    .HasColumnName("shape")
                    .HasColumnType("int");

            modelBuilder.Entity<Selection>().Property(e => e.Top)
                    .HasColumnName("top")
                    .HasColumnType("int");


            modelBuilder.Entity<Setting>().ToTable("setting");

            modelBuilder.Entity<Setting>().HasIndex(e => e.Name)
                    .HasName("name");

            modelBuilder.Entity<Setting>().Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Setting>().Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Setting>().Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

            modelBuilder.Entity<Setting>().Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("tinyint")
                    ;

            modelBuilder.Entity<Setting>().Property(e => e.ModifiedTime)
                    .HasColumnName("modifiedTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<Setting>().Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

            modelBuilder.Entity<Setting>().Property(e => e.Operator)
                    .HasColumnName("operator")
                    .HasMaxLength(255);

            modelBuilder.Entity<Setting>().Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasMaxLength(255);

            modelBuilder.Entity<User>().ToTable("user");

            modelBuilder.Entity<User>().Property(e => e.Id)
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<User>().Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("datetime");

            modelBuilder.Entity<User>().Property(e => e.CreateTime)
                    .HasColumnName("createTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<User>().Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

            modelBuilder.Entity<User>().Property(e => e.IdCard)
                    .HasColumnName("idCard")
                    .HasMaxLength(45);

            modelBuilder.Entity<User>().Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasColumnType("tinyint")
                    ;

            modelBuilder.Entity<User>().Property(e => e.IsEmailVerified)
                    .HasColumnName("isEmailVerified")
                    .HasColumnType("tinyint")
                    ;

            modelBuilder.Entity<User>().Property(e => e.IsMale)
                    .HasColumnName("isMale")
                    .HasColumnType("tinyint");

            modelBuilder.Entity<User>().Property(e => e.IsPhoneVerified)
                    .HasColumnName("isPhoneVerified")
                    .HasColumnType("tinyint")
                    ;

            modelBuilder.Entity<User>().Property(e => e.ModifiedTime)
                    .HasColumnName("modifiedTime")
                    .HasColumnType("datetime");

            modelBuilder.Entity<User>().Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

            modelBuilder.Entity<User>().Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100);

            modelBuilder.Entity<User>().Property(e => e.PasswordSalt)
                    .HasColumnName("passwordSalt")
                    .HasMaxLength(100);

            modelBuilder.Entity<User>().Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(100);

            modelBuilder.Entity<User>().Property(e => e.PrepayCard)
                    .HasColumnName("prepayCard")
                    .HasColumnType("bigint");

        }
    }
}
