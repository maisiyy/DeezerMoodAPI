# 🎵 Mood Music — ASP.NET Core Web API + Deezer API

A full-stack web application that recommends tracks based on your current mood, powered by the Deezer API and built with ASP.NET Core Web API.

---

## 📸 Preview

> Pick a mood → Get track recommendations → Preview & listen instantly

---

## 🚀 Features

- 7 mood categories: Happy, Sad, Chill, Angry, Romantic, Focus, Energetic
- Real track data from Deezer API (no auth required)
- 30-second audio preview player built into each card
- Adjustable track count (5, 10, 15)
- Clean dark-themed frontend (HTML + CSS + JS)
- RESTful API built with ASP.NET Core Web API

---

## 🛠️ Tech Stack

| Layer | Technology |
|-------|-----------|
| Backend | ASP.NET Core Web API (.NET 8) |
| Language | C# |
| Music Data | Deezer API |
| Frontend | HTML, CSS, Vanilla JavaScript |
| Testing | Postman |
| Version Control | Git & GitHub |

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/) or Visual Studio
- [Postman](https://www.postman.com/) (optional, for API testing)

### Installation

1. Clone the repo:
```bash
   git clone https://github.com/maisiyy/SpotifyMoodAPI.git
   cd SpotifyMoodAPI
```

2. Install dependencies:
```bash
   dotnet restore
   dotnet add package Newtonsoft.Json
   dotnet add package Swashbuckle.AspNetCore
```

3. Run the app:
```bash
   dotnet run
```

4. Open your browser:

http://localhost:5296

---

## 🔌 API Reference

### Get tracks by mood

GET /api/mood?mood={mood}&limit={limit}

**Query Parameters**

| Parameter | Type | Default | Description |
|-----------|------|---------|-------------|
| mood | string | happy | Mood keyword |
| limit | int | 10 | Number of tracks |

**Available moods**

`happy` `sad` `chill` `angry` `romantic` `focus` `energetic`

**Example Request**

GET http://localhost:5296/api/mood?mood=chill&limit=5

**Example Response**

```json
{
  "mood": "chill",
  "count": 5,
  "tracks": [
    {
      "trackName": "Lo-Fi Chill",
      "artist": "JS aka The Best",
      "album": "Chill Hop Vibes",
      "previewUrl": "https://cdnt-preview.dzcdn.net/...",
      "spotifyUrl": "https://www.deezer.com/track/914978492"
    }
  ]
}
```

---

## 🧪 Testing with Postman

1. Run the app with `dotnet run`
2. Open Postman
3. Set method to `GET`
4. Enter URL: `http://localhost:5296/api/mood?mood=happy&limit=5`
5. Click **Send**

---

## 📌 Notes

- This project was built as part of an API learning exercise
- Originally planned with Spotify Web API — migrated to Deezer API due to Spotify Premium restrictions on developer apps
- No API key required for Deezer

---

