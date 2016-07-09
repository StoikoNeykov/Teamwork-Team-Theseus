using Newtonsoft.Json;

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
    struct Level
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

        public Level(string filePath)
        {
            try
            {




                //using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                //{
                //    XmlDocument doc=new XmlDocument();
                //    doc.Load(stream);

                //    int width=int.Parse(doc.DocumentElement.GetAttribute("width"));
                //    int height = int.Parse(doc.DocumentElement.GetAttribute("height"));

                //    grid = new Block[width, height];
                //    this.fileName = filePath;
                //    playerStartPos = new Point(1, 1);

                //    XmlNode tileLeyer = doc.DocumentElement.SelectSingleNode("layer[@name='Tile Layer 1']");
                //    XmlNodeList tiles = tileLeyer.SelectSingleNode("data").SelectNodes("tile");

                //    /////To do 
                //    /// 

                //}
                using (JsonTextReader reader = new JsonTextReader(new StreamReader(filePath)))
                {
                    RootObject root = JsonConvert.DeserializeObject<RootObject>(reader.ToString());



                }


            }
            catch (Exception e)
            {
                int width = 20;
                int height = 20;
                grid = new Block[width, height];
                fileName = "none";

                playerStartPos = new Point(1, 1);

                for (int x = 0; x < width; x++)
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

    struct  Block
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
