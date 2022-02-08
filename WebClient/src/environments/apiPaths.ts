export enum ApiPaths {
  loginService = "/login",
  registerService = "/register",
  mediaService = "/mediaServe",
  albumInfoGet = "/mediaMetadata/album",
  songInfoGet = "/mediaMetadata/song",
  searchResultsGet = "/mediaSearch/search",

  uploadAlbumPost = "/MediaUpload",
  uploadAlbumMetadataPost = "/MediaMetadata/createAlbum",


  createPlaylistPost = "/Playlist/create",
  addSongPatch = "/Playlist/addSong",
  deleteSong = "/Playlist/deleteSong",
  playlistByIdGet = "/Playlist/playlist",
  myPlaylistsGet = "/Playlist/myPlaylists",
}
