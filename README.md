# ytb-dl
YouTube Bulk Downloader


YouTube Bulk Downloader is a command line application to help you automate downloading YouTube videos in large quantities in few easy steps.
You can subscribe to several channels and/or playlists and download latest videos from your favorite content creators.

## Commands

### Fetch

The fetch command fetches the latest videos posted on your subscribed channels / playlists and adds them to the download list.

```ytb-dl fetch```
```ytb-dl fetch --fetchlist "myFetchList"```

### Subs

The subs command allows you to keep track of you subscribed channels / playlists, add new ones or removes existing ones. You can manage your subscriptions in several fetch lists to organize.

```ytb-dl subs add --fetchlist Humour MrBeast```
```ytb-dl subs remove MrBeast```
```ytb-dl subs list --fetchlist Humour```

### Download

The download command allows you to download a single video, or multiple ones from your download list in bulk. 

```ytb-dl download list```
```ytb-dl download remove 2```
```ytb-dl download --single erLbbextvlY```
```ytb-dl download```

### Config

The config command allows you to configure ytb-dl output video path and YouTube API Key.

```ytb-dl config --output C:/Videos/YTBdl```
```ytb-dl config --key MY_API_KEY```