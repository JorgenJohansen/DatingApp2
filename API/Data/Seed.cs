using System.Text.Json;
using API.Data;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager)
        {
            if(await userManager.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});
            foreach(var user in users)
            {
                user.UserName = user.UserName.ToLower();
                

                await userManager.CreateAsync(user, "Pa$$w0rd");

            }
        }
    }
}