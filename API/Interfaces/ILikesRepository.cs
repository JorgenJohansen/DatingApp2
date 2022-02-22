using DTOs;
using Entities;

namespace Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId, int likedUserId);

        Task<AppUser> GetUserWithlikes(int userId);

        Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId);
    }
}