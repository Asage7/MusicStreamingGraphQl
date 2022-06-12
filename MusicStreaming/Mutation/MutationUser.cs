using MusicStreaming.Data;
using MusicStreaming.Models;

namespace MusicStreaming.Mutation
{
    [ExtendObjectType(typeof(Mutation))]
    public class MutationUser
    {
        [UseProjection]
        [UseFiltering]
        public User CreateUser([Service] AppDBContext context, string name, int idade)
        {
            User user = new User
            {
                Id = new Guid(),
                Name = name,
                Idade = idade
            };

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }
        [UseProjection]
        [UseFiltering]
        public User AlterUser([Service] AppDBContext context, Guid id, string name, int idade)
        {
            var userdb = context.Users.FirstOrDefault(x => x.Id == id);
            if (userdb == null)
                throw new Exception("User not found");

            userdb.Name = name;
            userdb.Idade = idade;

            context.Update(userdb);
            context.SaveChanges();

            return userdb;

        }
        [UseProjection]
        [UseFiltering]
        public bool DeleteUser([Service] AppDBContext context, Guid id)
        {
            var userdb = context.Users.FirstOrDefault(x => x.Id == id);
            if (userdb == null)
                throw new Exception("User not found");
            context.Users.Remove(userdb);
            context.SaveChanges();
            return true;
        }
    }
}
