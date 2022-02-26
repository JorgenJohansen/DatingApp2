using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Data;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if(await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});
            foreach(var user in users)
            {
                user.UserName = user.UserName.ToLower();
                

                context.Users.Add(user);

            }
            await context.SaveChangesAsync();
        }
    }
}