# Capi
 A Command API for any chat software

 by importing the api into your project, any command which derrives from Command type and has a Cmd attribute will be usable immediately through the command handler's DoCommands method. 

 you control what comes out of your commands.

 making a discord bot which needs to export an embed builder through a command? 

 return the embed builder in your commands overridden do work command, when the command is used it'll output a list of objects.
 Don't worry, loop through the list and the items type for embed builder and cast it to embed builder. or 

  ```csharp 
    foreach (var RetObj in RetObjs) {
    if (RetObj is EmbedBuilder eb) await DiscordChannel.SendMessageAsync(null, false, eb.Build());
    }
  ```

 You control what goes in and comes out through the imsgdata interface entrance and the object exit.

 That is all.  Have fun sillies.
