using System;

namespace SboxUtils;

public static class LoggerExtensions
{
    public static void Side(this Sandbox.Logger self, object inMessage, bool withChat = false)
    {
        var prefix = Host.IsServer ? "[SERVER]" : "[CLIENT]";
        self.Info($"{prefix}: {inMessage.ToString()}");

        if (!withChat) return;

        if (Host.IsClient)
        {
            Sandbox.UI.ChatBox.AddChatEntry(prefix, inMessage.ToString());
        }
    }

}