using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace GameLogic.GameGenerator
{
    using System;
    using OpenTK;
    using System.Drawing;
    using System.IO;
    using Models;
    using System.Xml;

    public class Item
    {
        public int data;

    }
  public class Level
    {
        private Block[,] grid;
        private string fileName;
        public Point playerStartPos;

        public Block this[int x, int y]
        {
            get
            {
                return grid[x, y];
            }
            set
            {
                grid[x, y] = value;

            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }
        }

        public int Width
        {
            get
            {
                return grid.GetLength(0);
            }
        }
        public int Height
        {
            get
            {
                return grid.GetLength(1);
            }
        }
        public static T ParseJsonObject<T>(string json)
            where T : class, new()
        {
            JObject jobject = JObject.Parse(json);
            return JsonConvert.DeserializeObject<T>(jobject.ToString());
        }
        public Level(string filePath)
        {
            try
            {

               // var jsreader = new JsonTextReader(new StringReader(filePath));
               // var json = (JObject) new JsonSerializer().Deserialize(jsreader);

             
                //JObject obj=JObject.Parse(File.ReadAllText(filePath));
                using (StreamReader file = new StreamReader(filePath))
                {
                    var str = file.ReadToEnd();
                    JObject search=JObject.Parse(str);
                    IList<JToken> result = search["layers"][0]["data"].Children().ToList();

                    Map root = JsonConvert.DeserializeObject<Map>(str);
                    int width = root.Width;
                    int height = root.Height;

                    grid = new Block[width, height];
                    this.fileName = filePath;
                    playerStartPos = new Point(1, 1);
                    IList<JToken> tileset = search["tilesets"].ToList();

                    Map myObj = JsonConvert.DeserializeObject<Map>(str);

                    Layer lyer = JsonConvert.DeserializeObject<Layer>(str);
               
                     

                    int x = 0, y = 0;
                    for (int i = 0; i < result.Count; i++)
                    {
                        int gid = int.Parse(result[i].ToString());


                        switch (gid)
                        {
                            default:
                                grid[x, y] = new Block(BlockType.Empty, x, y);
                                break;
                            case 1:
                                grid[x, y] = new Block(BlockType.Ice_Block, x, y);
                                break;
                            case 2:
                                grid[x, y] = new Block(BlockType.Brick_Block, x, y);
                                break;
                            case 3:
                                grid[x, y] = new Block(BlockType.StoneBlocks, x, y);
                                break;
                            case 4:
                                grid[x, y] = new Block(BlockType.diamand, x, y);
                                break;
                            case 5:
                                grid[x, y] = new Block(BlockType.Paper, x, y);
                                break;
                        }
                        x++;
                        if (x >= width)
                        {
                            x = 0;
                            y++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                //int width = 20;
                //int height = 20;
                //grid = new Block[width, height];
                //fileName = "none";

                //playerStartPos = new Point(1, 1);

                //for (int x = 0; x < width; x++)
                //{
                //    for (int y = 0; y < height; y++)
                //    {
                //        if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                //        {
                //            grid[x, y] = new Block(BlockType.Brick_Block, x, y);

                //        }
                //        else
                //        {
                //            grid[x, y] = new Block(BlockType.Empty, x, y);

                //        }
                //    }
                //}
            }
        }

        public Level(int width, int height)
        {
            grid = new Block[width, height];
            fileName = "none";
            
            playerStartPos = new Point(1, 1);

            for (int x = 0; x< width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        grid[x, y] = new Block(BlockType.Brick_Block, x, y);

                    }
                    else
                    {
                        grid[x, y] = new Block(BlockType.Empty, x, y);

                    }
                }
            }

        }
    }

    public enum BlockType
    {
        Ice_Block,
        Brick_Block,
        StoneBlocks,
        diamand,
        Paper,
        Empty
    }

    public struct  Block
    {
        private BlockType type;
        private int posX, posY;
        private bool brickBlock, diamond, paper, stoneblock, ice_Block,empty;

        public BlockType Type
        {
            get
            {
                return type;
            }
        }

        public int X
        {
            get { return posX; }
        }

        public int Y
        {
            get { return posY;}
        }

        public bool IsBrickBlock
        {
            get
            {
                return brickBlock;
            }
        }

        public bool IsDiamond
        {
            get
            {
                return diamond;
            }
        }

        public bool IsPaper
        {
            get
            {
                return paper;
            }
        }

        public bool IsStoneBlock
        {
            get
            {
                return stoneblock;
            }
        }

        public bool IsIceBlock
        {
            get { return ice_Block; }
        }

        public bool isEmpty
        {
            get
            {
                return empty;
            }
        }

        public Block(BlockType type, int x, int y)
        {
            this.posX = x;
            this.posY = y;
            this.type = type;
            this.brickBlock = false;
            this.diamond = false;
            this.paper = false;
            this.stoneblock = false;
            this.ice_Block = false;
            this.empty = false;
            switch (type)
            {
                    case BlockType.Brick_Block:
                    brickBlock = true;
                    break;
                    case BlockType.Ice_Block:
                    ice_Block = true;
                    break;
                    case BlockType.Paper:
                    paper = true;
                    break;
                    case BlockType.StoneBlocks:
                    stoneblock = true;
                    break;
                    case BlockType.diamand:
                    diamond = true;
                    break;
                    case BlockType.Empty:
                    empty = true;
                    break;
                default:
                    break;
            }
        }
    }
}
