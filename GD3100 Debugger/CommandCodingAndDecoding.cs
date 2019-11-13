using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GD3100Debugger
{
    class CommandCodingAndDecoding
    {
        public enum DecodeResult
        {
            COMMAND_OK = 0,
            COMMAND_OVERFLOW = 1,
            COMMAND_ERR_FORMAT = 2,
            COMMAND_NOP = 3,
            COMMAND_NONE_VALUE = 4,
        };
        public delegate void CommandFinishDelegate(DecodeResult result, string key, string value);
        public CommandFinishDelegate CommandFinishHandler = null;

        private static string CommandHead = "AT";
        private static string CommandConnect = "+";
        private static string CommandSplit = "=";
        private static string CommandEnd = "\r\n";

        private StringBuilder pool = new StringBuilder();

        CommandCodingAndDecoding(CommandFinishDelegate handler)
        {
            CommandFinishHandler = handler;
        }

        public static string Coding(string key, string value)
        {
            return CommandHead + CommandConnect + key + CommandSplit + value;
        }
        public void Decoding(byte[] data)
        {
            char[] endbuf = new char[2];
            DecodeResult result = DecodeResult.COMMAND_OK;
            string key = null;
            string value = null;
            pool.Append(data);

            if (pool.Length < 2)
            {
                return;
            }

            pool.CopyTo(pool.Length - 2, endbuf, 0, 2);

            if (endbuf[0] == '\r' && endbuf[1] == '\n')
            {
                if (pool.ToString().StartsWith(CommandHead) == false)
                {
                    pool.Clear();
                    CommandFinishHandler(DecodeResult.COMMAND_ERR_FORMAT, key, value);
                    return;
                }

                string[] strings = pool.ToString().Split(new string[] { CommandConnect }, StringSplitOptions.None);
                pool.Clear();
                if (strings == null || strings.Length == 0 || strings[0].Trim().CompareTo(CommandHead) != 0)
                {
                    result = DecodeResult.COMMAND_ERR_FORMAT;
                }
                else if (strings.Length == 1)
                {
                    result = DecodeResult.COMMAND_NOP;
                }
                else
                {
                    string[] keyValue = strings[1].Split(new string[] { CommandSplit }, StringSplitOptions.RemoveEmptyEntries);

                    key = keyValue[0].Trim();
                    if (key.Length == 0)
                    {
                        key = null;
                        result = DecodeResult.COMMAND_ERR_FORMAT;
                    }
                    else
                    {
                        if (keyValue.Length == 1)
                        {
                            result = DecodeResult.COMMAND_NONE_VALUE;
                        }
                        else
                        {
                            value = keyValue[1].Trim;
                            if (value.Length == 0)
                            {
                                result = DecodeResult.COMMAND_NONE_VALUE;
                                value = null;
                            }
                            else
                            {
                                result = DecodeResult.COMMAND_OK;
                            }
                        }
                    }
                }
                CommandFinishHandler(result, key, value);
            }
        }
    }
}
