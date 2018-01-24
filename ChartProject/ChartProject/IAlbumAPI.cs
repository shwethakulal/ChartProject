using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChartProject
{
    public interface IAlbumAPI
    {
        [Get("/albums")]
        Task<List<Album>> GetAllAlbums();

        [Get("/albums/{userId}")]
        Task<List<Album>> GetUser(int userId);
    }
}
