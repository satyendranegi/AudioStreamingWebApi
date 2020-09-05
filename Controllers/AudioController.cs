using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using AudioStreaming.Models;

namespace AudioStreaming.Controllers
{
    public class AudioController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(string filename, string ext)
        {
            var video = new AudioStream(filename, ext);

            var response = Request.CreateResponse();
            response.Content = new PushStreamContent(video.WriteToStream, new MediaTypeHeaderValue("video/" + ext));

            return response;
        }

        [HttpGet]
        public IEnumerable<AudioRecord> AudioList(int start, int end)
        {
            var db = new AudioDBEntities();
            var DATA_ITEMS = db.sp_AudioPagination(start, end);

            var selectList = new List<AudioRecord>();

            foreach (var r in DATA_ITEMS.ToList())
            {

                selectList.Add(new AudioRecord { Name = r.Name.ToString(), Title = r.Title.ToString() });

            }

            return selectList;
        }

        [HttpGet]
        public IEnumerable<AudioRecord> TrackListByArtist(string Artist)
        {
            var db = new AudioDBEntities();
            var DATA_ITEMS = db.sp_SongListByArtist(Artist);

            var TrackList = new List<AudioRecord>();

            foreach (var r in DATA_ITEMS.ToList())
            {

                TrackList.Add(new AudioRecord { Name = r.Name.ToString(), Title = r.Title.ToString() });

            }

            return TrackList;
        }

        [HttpGet]
        public IEnumerable<AudioRecord> SearchTrack(string SearchTrack)
        {
            var db = new AudioDBEntities();
            var DATA_ITEMS = db.sp_SearchTrack(SearchTrack);

            var SearchTrackList = new List<AudioRecord>();

            foreach (var r in DATA_ITEMS.ToList())
            {

                SearchTrackList.Add(new AudioRecord { Name = r.Name.ToString(), Title = r.Title.ToString() });

            }

            return SearchTrackList;
        }
    }
}
