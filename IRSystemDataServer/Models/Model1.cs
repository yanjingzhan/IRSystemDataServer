namespace IRSystemDataServer.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<admin_user> admin_user { get; set; }
        public virtual DbSet<admin_user_role> admin_user_role { get; set; }
        public virtual DbSet<apointment> apointments { get; set; }
        public virtual DbSet<area> areas { get; set; }
        public virtual DbSet<camera> cameras { get; set; }
        public virtual DbSet<doctor_machinery> doctor_machinery { get; set; }
        public virtual DbSet<doctorreportcategory> doctorreportcategories { get; set; }
        public virtual DbSet<doctorreportoption> doctorreportoptions { get; set; }
        public virtual DbSet<gesture> gestures { get; set; }
        public virtual DbSet<infrareddata> infrareddatas { get; set; }
        public virtual DbSet<invoice> invoices { get; set; }
        public virtual DbSet<machinery> machineries { get; set; }
        public virtual DbSet<membership> memberships { get; set; }
        public virtual DbSet<membershiptype> membershiptypes { get; set; }
        public virtual DbSet<nine_ask> nine_ask { get; set; }
        public virtual DbSet<nine_ask_questionnaire> nine_ask_questionnaire { get; set; }
        public virtual DbSet<permission> permissions { get; set; }
        public virtual DbSet<physicalexamination> physicalexaminations { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<role_permission> role_permission { get; set; }
        public virtual DbSet<selection> selections { get; set; }
        public virtual DbSet<setting> settings { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<admin_user>()
                .Property(e => e.account)
                .IsUnicode(false);

            modelBuilder.Entity<admin_user>()
                .Property(e => e.passwordSalt)
                .IsUnicode(false);

            modelBuilder.Entity<admin_user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<admin_user>()
                .Property(e => e.phoneNum)
                .IsUnicode(false);

            modelBuilder.Entity<admin_user>()
                .Property(e => e._operator)
                .IsUnicode(false);

            modelBuilder.Entity<admin_user>()
                .Property(e => e.realName)
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .Property(e => e.areaid)
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .Property(e => e.parentId)
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .Property(e => e.lel)
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .Property(e => e.mergerName)
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .Property(e => e.zipcode)
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .Property(e => e._short)
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .Property(e => e.mergershortname)
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .Property(e => e.pinyin)
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .Property(e => e.jianpin)
                .IsUnicode(false);

            modelBuilder.Entity<area>()
                .Property(e => e.first)
                .IsUnicode(false);

            modelBuilder.Entity<camera>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<camera>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<camera>()
                .Property(e => e.idCard)
                .IsUnicode(false);

            modelBuilder.Entity<camera>()
                .Property(e => e.faceFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<camera>()
                .Property(e => e.tongueFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<camera>()
                .Property(e => e.handFrontFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<camera>()
                .Property(e => e.handBackFilePath)
                .IsUnicode(false);

            modelBuilder.Entity<camera>()
                .Property(e => e.doctor)
                .IsUnicode(false);

            modelBuilder.Entity<camera>()
                .Property(e => e._operator)
                .IsUnicode(false);

            modelBuilder.Entity<doctor_machinery>()
                .Property(e => e.doctorName)
                .IsUnicode(false);

            modelBuilder.Entity<doctor_machinery>()
                .Property(e => e.doctorPhone)
                .IsUnicode(false);

            modelBuilder.Entity<doctor_machinery>()
                .Property(e => e.machineCode)
                .IsUnicode(false);

            modelBuilder.Entity<doctor_machinery>()
                .Property(e => e.machineAddress)
                .IsUnicode(false);

            modelBuilder.Entity<doctorreportcategory>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<doctorreportoption>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<doctorreportoption>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<gesture>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<gesture>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<gesture>()
                .Property(e => e.gesturecol)
                .IsUnicode(false);

            modelBuilder.Entity<infrareddata>()
                .Property(e => e.dataFile)
                .IsUnicode(false);

            modelBuilder.Entity<invoice>()
                .Property(e => e.payType)
                .IsUnicode(false);

            modelBuilder.Entity<invoice>()
                .Property(e => e.payAccount)
                .IsUnicode(false);

            modelBuilder.Entity<machinery>()
                .Property(e => e.machinecode)
                .IsUnicode(false);

            modelBuilder.Entity<machinery>()
                .Property(e => e.machinefile)
                .IsUnicode(false);

            modelBuilder.Entity<machinery>()
                .Property(e => e.productType)
                .IsUnicode(false);

            modelBuilder.Entity<machinery>()
                .Property(e => e.areaid)
                .IsUnicode(false);

            modelBuilder.Entity<machinery>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<membershiptype>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<nine_ask>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<nine_ask_questionnaire>()
                .Property(e => e.nineAsk)
                .IsUnicode(false);

            modelBuilder.Entity<nine_ask_questionnaire>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<nine_ask_questionnaire>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<nine_ask_questionnaire>()
                .Property(e => e.idCard)
                .IsUnicode(false);

            modelBuilder.Entity<permission>()
                .Property(e => e.path)
                .IsUnicode(false);

            modelBuilder.Entity<permission>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<physicalexamination>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<physicalexamination>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<physicalexamination>()
                .Property(e => e.idCard)
                .IsUnicode(false);

            modelBuilder.Entity<physicalexamination>()
                .Property(e => e.doctor)
                .IsUnicode(false);

            modelBuilder.Entity<physicalexamination>()
                .Property(e => e._operator)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<setting>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<setting>()
                .Property(e => e.value)
                .IsUnicode(false);

            modelBuilder.Entity<setting>()
                .Property(e => e._operator)
                .IsUnicode(false);

            modelBuilder.Entity<setting>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.passwordSalt)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.idCard)
                .IsUnicode(false);
        }
    }
}
