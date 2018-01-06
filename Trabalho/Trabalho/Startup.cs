using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Trabalho.Models;

[assembly: OwinStartupAttribute(typeof(Trabalho.Startup))]
namespace Trabalho
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        // In this method we will create default User roles and Admin user for login    
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            //    
            if (!roleManager.RoleExists("Administrador"))
            {

                // CRIAÇÃO DO PERFIL DE ADMINISTRADOR 
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Administrador";
                roleManager.Create(role);

                // CRIAÇÃO DE CONTA SUPER ADMIN               

                var user = new ApplicationUser();
                user.UserName = "admin@pw.pw";
                user.Email = "admin@pw.pw";

                string userPWD = "Admin_123";

                var chkUser = UserManager.Create(user, userPWD);

                //ASSOCIA ESSA CONTA AO PERFIL ADMINISTRADOR    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Administrador");

                }
            }

            
            if (!roleManager.RoleExists("Pais"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Pais";
                roleManager.Create(role);

                // CRIAÇÃO DE CONTA            
                var user2 = new ApplicationUser();
                user2.UserName = "pais@pw.pw";
                user2.Email = "pais@pw.pw";

                string userPWD = "Pais_123";

                var chkUser = UserManager.Create(user2, userPWD);

                //ASSOCIA ESSA CONTA AO PERFIL    
                if (chkUser.Succeeded)
                {
                    var result2 = UserManager.AddToRole(user2.Id, "Pais");
                }
            }

            if (!roleManager.RoleExists("Instituição"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Instituição";
                roleManager.Create(role);

                // CRIAÇÃO DE CONTA            
                var user3 = new ApplicationUser();
                user3.UserName = "inst@pw.pw";
                user3.Email = "inst@pw.pw";

                string userPWD = "Inst_123";

                var chkUser = UserManager.Create(user3, userPWD);

                //ASSOCIA ESSA CONTA AO PERFIL    
                if (chkUser.Succeeded)
                {
                    var result3 = UserManager.AddToRole(user3.Id, "Instituição");
                }
            }

               
            //if (!roleManager.RoleExists("Geral"))
            //{
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Geral";
            //    roleManager.Create(role);


            //    // CRIAÇÃO DE CONTA            
            //    var user4 = new ApplicationUser();
            //    user4.UserName = "geral@pw.pw";
            //    user4.Email = "geral@pw.pw";

            //    string userPWD = "Geral_123";

            //    var chkUser = UserManager.Create(user4, userPWD);

            //    //ASSOCIA ESSA CONTA AO PERFIL    
            //    if (chkUser.Succeeded)
            //    {
            //        var result4 = UserManager.AddToRole(user4.Id, "Geral");
            //    }
            //}
        }

    }
}
