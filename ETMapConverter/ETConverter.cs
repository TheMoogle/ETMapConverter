using System;
using System.Collections.Generic;
using System.IO;

namespace ETMapConverter
{
    public class ETConverter
    {
        public static Dictionary<int, string> rooms = new Dictionary<int, string>() 
        {
            {0,  "68e4ada0-7276-4ad6-b53a-c0b12490e80d"},
            {1,  "30c57b2b-866c-4b17-9902-ea8e023d78d6"},
            {2,  "df38e46b-8c1b-4a67-9c67-74e812709bc6"},
            {4,  "307cdb31-76f9-45c2-badc-8544648a4c62"},
            {5,  "c56d29cb-8d9e-4c25-86db-eeaf4cfa6f49"},
            {9,  "f7a08b97-065b-4b67-92aa-bd25ce31df65"},
            {10, "88da57df-2344-4ea1-ba7e-0af29cf626d5"},
            {11, "c9f75e91-a22f-41de-9d7f-16e415fe0271"},
            {12, "1cfa39e3-a857-4994-af8c-0ea3a100b870"},
            {14, "295ce2a8-748a-4a16-8368-a29cd3ff8faa"},
            {15, "501ae11f-42a7-4a24-8142-86478da46461"},
            {16, "c577b207-9a43-45ff-8eea-2c358bb5ac3d"},
            {17, "5ff3b114-43b8-4930-879d-d67aefeb3c72"},
            {18, "0601bc33-9ae1-4ce2-ac83-4c5d26e40b69"},
            {19, "649c9e69-0a7b-4da3-abaa-f67769863f24"},
            {20, "2b7a7239-8886-4b40-8a5e-db15a9facde1"},
            {21, "d1e25f6a-2b0d-42ac-92f1-fb2383180448"},
            {23, "2499bf03-d462-4c3e-8c31-6c0e4e53c3ec"},
            {24, "8a3c09fb-4592-4332-a403-1dd6dc92a999"},
            {25, "fd592222-3f12-47e2-8426-ce117b2d7bfc"},
            {26, "8dbef403-f03b-4661-b1aa-32b312f289fb"},
            {27, "834bffb0-eb7c-4c33-a2bc-bf3d41254dab"},
            {28, "fe8960f4-669b-480e-b38b-1b347de936b3"},
            {29, "e84d8af4-158d-4172-9d11-d27eb7c673b2"},
            {30, "c4c7338f-7a92-4ed1-8c78-ffb54a750c9a"},
            {31, "0b453db1-deec-4afd-a8c6-051128347896"},
            {32, "d47a9ef1-8333-4b9a-88da-7f92567012c6"},
            {34, "3ad15fc8-3b10-4bb7-9edc-fbf0df97f271"},
            {35, "c6d460a8-c02d-4ac9-9227-5a4f2acc30fd"},
            {36, "3c31550a-9d75-45db-b637-213f8e59e4bc"},
            {37, "101342a0-b4c3-49f3-a051-476e01af291e"},
            {39, "9db1f704-b776-4810-a7e6-efc49f3a90ac"},
            {41, "8d3a09ec-b6de-4091-8ed0-3110e87274db"},
            {42, "b781a275-288e-4a18-8938-f13885ab3d0b"},
        };

        static void Main(string[] args)
        {
            List<string> files = new List<string>();
            try
            {
                foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory()))
                {
                    if (file.EndsWith(".json"))
                        files.Add(file);
                }
            }
            catch(Exception e)
            {
                Console.Write(e);
                return;
            }
            ConvertList(files);
        }

        public static void ConvertList(List<string> files)
        {
            foreach (var file in files)
            {
                string FileContents = File.ReadAllText(file);
                foreach (var key in rooms.Keys)
                {
                    FileContents = FileContents.Replace($"\"RoomName\": {key},", $"\"RoomName\": {rooms[key]},");
                }
                File.WriteAllText(file, FileContents);
                Debug($"{Path.GetFileName(file)} is finished being Converted");
            }
        }

        public static void ConvertList(string[] files)
        {
            foreach (var file in files)
            {
                string FileContents = File.ReadAllText(file);
                foreach (var key in rooms.Keys)
                {
                    FileContents = FileContents.Replace($"\"RoomName\": {key},", $"\"RoomName\": {rooms[key]},");
                }
                File.WriteAllText(file, FileContents);
                Debug($"{Path.GetFileName(file)} is finished being Converted");
            }
        }

        static void Debug(string value) =>
            Console.WriteLine(value);
    }
}
