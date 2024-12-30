using System.Text;
using System.Text.Json;

namespace xuanthulab.file
{

    public static class PlayWithStream

    {
        /// <summary>
        /// Stream là đối tượng được sử dụng để đọc hoặc ghi dữ liệu từ một nguồn nào đó
        /// Stream không phụ thuộc vào nguồn dữ liệu cụ thể, nó có thể là file, memory, network, ...
        /// </summary>
        public static void StreamExample()
        {
            var stream = new MemoryStream();
            for (var i = 0; i < 122; i++)
            {
                stream.WriteByte((byte)i);
            }
            stream.Position = 0;
            var buffer = new byte[10];
            const int offset = 0;
            const int count = 5;
            var numberByte = stream.Read(buffer, 0, 2); // bắt đầu đọc
            while (numberByte != 0)
            {
                Console.Write($"{numberByte} bytes: ");
                for (var i = 1; i <= numberByte; i++)
                {
                    var b = buffer[i - 1];
                    Console.Write($"{b,5}");

                }
                numberByte = stream.Read(buffer, offset, count); // đọc 5 byte tiếp theo
                Console.WriteLine();
            }
        }

        /// <summary>
        /// FileStream là một lớp kế thừa từ lớp Stream, nó được sử dụng để đọc hoặc ghi dữ liệu từ file
        /// Không được quản lý bởi Garbage Collector nên cần phải giải phóng tài nguyên bằng cách gọi phương thức Dispose, bằng using hoặc gọi phương thức Close
        /// </summary>
        public static void WriteFileStreamExample()
        {
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "FileStream"));
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "FileStream", "data.txt");
            using var fileStream = new FileStream(path: filePath, mode: FileMode.OpenOrCreate, access: FileAccess.ReadWrite, share: FileShare.Read);

            var encoding = Encoding.UTF8;
            var bom = encoding.GetPreamble();
            fileStream.Write(bom, 0, bom.Length);

            var stringBuilder = new StringBuilder();
            for (var i = 0; i < 100; i++)
            {
                stringBuilder.AppendLine($"Line {i}");
            }
            var data = encoding.GetBytes(stringBuilder.ToString());
            fileStream.Write(data, 0, data.Length);
        }

        public static void ReadFileStreamExample()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "FileStream", "data.txt");
            using var fileStream = new FileStream(path: filePath, mode: FileMode.Open, access: FileAccess.Read, share: FileShare.Read);
            var encoding = Encoding.UTF8;
            var buffer = new byte[1024];
            var numberByte = fileStream.Read(buffer, 0, buffer.Length);
            while (numberByte != 0)
            {
                var data = encoding.GetString(buffer, 0, numberByte);
                Console.Write(data);
                numberByte = fileStream.Read(buffer, 0, buffer.Length);
            }
        }

        public static void WriteFileBinary(string fileName, Student student)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "FileStream", fileName);
            using var fileStream = new FileStream(path: filePath, mode: FileMode.OpenOrCreate, access: FileAccess.Write, share: FileShare.None);
            using var binaryWriter = new BinaryWriter(fileStream);
            // Serialize student to JSON format and save
            var json = JsonSerializer.Serialize(student);
            binaryWriter.Write(json);
            binaryWriter.Close();
            fileStream.Close();
        }
    }
}
