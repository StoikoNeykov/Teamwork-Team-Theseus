using System.IO;
using Newtonsoft.Json;

namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RootObject
    {
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("layers")]
        public List<Layer> Layers { get; set; }
        [JsonProperty("nextobjectid")]
        public int Nextobjectid { get; set; }
        [JsonProperty("orientation")]
        public string Orientation { get; set; }
        [JsonProperty("renderorder")]
        public string Renderorder { get; set; }
        [JsonProperty("tileheight")]
        public int Tileheight { get; set; }
        [JsonProperty("tilesets")]
        public List<Tileset> Tilesets { get; set; }
        [JsonProperty("tilewidth")]
        public int Tilewidth { get; set; }
        [JsonProperty("version")]
        public int Version { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
    }
    public class Layer
    {
        [JsonProperty("data")]
        public List<int> Data { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("opacity")]
        public int Opacity { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("visible")]
        public bool Visible { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("x")]
        public int X { get; set; }
        [JsonProperty("y")]
        public int Y { get; set; }
    }
    public class Tileset
    {
        [JsonProperty("columns")]
        public int Columns { get; set; }
        [JsonProperty("firstgid")]
        public int Firstgid { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("imageheight")]
        public int Imageheight { get; set; }
        [JsonProperty("imagewidth")]
        public int Imagewidth { get; set; }
        [JsonProperty("margin")]
        public int Margin { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("spacing")]
        public int Spacing { get; set; }
        [JsonProperty("tilecount")]
        public int Tilecount { get; set; }
        [JsonProperty("tileheight")]
        public int Tileheight { get; set; }
        [JsonProperty("tilewidth")]
        public int Tilewidth { get; set; }
        [JsonProperty("transparentcolor")]
        public string Transparentcolor { get; set; }
    }

}
