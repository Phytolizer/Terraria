﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Shaders.SandstormShaderData
// Assembly: TerrariaServer, Version=1.3.4.4, Culture=neutral, PublicKeyToken=null
// MVID: C7ED7F12-DBD9-42C5-B3E5-7642F0F95B55
// Assembly location: E:\Steam\SteamApps\common\Terraria\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Shaders
{
  public class SandstormShaderData : ScreenShaderData
  {
    private Vector2 _texturePosition = Vector2.Zero;

    public SandstormShaderData(string passName)
      : base(passName)
    {
    }

    public override void Update(GameTime gameTime)
    {
      Vector2 vector2 = new Vector2(-Main.windSpeed, -1f) * new Vector2(20f, 0.1f);
      vector2.Normalize();
      Vector2 direction = vector2 * new Vector2(2f, 0.2f);
      if (!Main.gamePaused && Main.hasFocus)
        this._texturePosition += direction * (float) gameTime.ElapsedGameTime.TotalSeconds;
      this._texturePosition.X %= 10f;
      this._texturePosition.Y %= 10f;
      this.UseDirection(direction);
      base.Update(gameTime);
    }

    public override void Apply()
    {
      this.UseTargetPosition(this._texturePosition);
      base.Apply();
    }
  }
}