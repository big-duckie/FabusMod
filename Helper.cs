using System;
using Microsoft.Xna.Framework;
using Terraria;

namespace FabusMod;

public static class Helper
{
	public static Vector2 RandomPosition(Vector2 pos1, Vector2 pos2)
	{
		return new Vector2(Main.rand.Next((int)pos1.X, (int)pos2.X) + 1, Main.rand.Next((int)pos1.Y, (int)pos2.Y) + 1);
	}

	public static int GetNearestAlivePlayer(NPC npc)
	{
		float NearestPlayerDist = 4.8151624E+09f;
		int NearestPlayer = -1;
		Player[] player2 = Main.player;
		foreach (Player player in player2)
		{
			if (player.Distance(npc.Center) < NearestPlayerDist && player.active)
			{
				NearestPlayerDist = player.Distance(npc.Center);
				NearestPlayer = player.whoAmI;
			}
		}
		return NearestPlayer;
	}

	public static Vector2 VelocityFPTP(Vector2 pos1, Vector2 pos2, float speed)
	{
		Vector2 move = pos2 - pos1;
		return move * (speed / (float)Math.Sqrt(move.X * move.X + move.Y * move.Y));
	}

	public static int GetNearestNPC(Vector2 Point, bool Friendly = false, bool NoBoss = false)
	{
		float NearestNPCDist = -1f;
		int NearestNPC = -1;
		NPC[] npc2 = Main.npc;
		foreach (NPC npc in npc2)
		{
			if (npc.active && (!NoBoss || !npc.boss) && (Friendly || (!npc.friendly && npc.lifeMax > 5)) && (NearestNPCDist == -1f || npc.Distance(Point) < NearestNPCDist))
			{
				NearestNPCDist = npc.Distance(Point);
				NearestNPC = npc.whoAmI;
			}
		}
		return NearestNPC;
	}

	public static int GetNearestPlayer(Vector2 Point, bool Alive = false)
	{
		float NearestPlayerDist = -1f;
		int NearestPlayer = -1;
		Player[] player2 = Main.player;
		foreach (Player player in player2)
		{
			if ((!Alive || (player.active && !player.dead)) && (NearestPlayerDist == -1f || player.Distance(Point) < NearestPlayerDist))
			{
				NearestPlayerDist = player.Distance(Point);
				NearestPlayer = player.whoAmI;
			}
		}
		return NearestPlayer;
	}

	public static int GetNearestPlayer(this NPC npc)
	{
		float NearestPlayerDist = 4.8151624E+09f;
		int NearestPlayer = -1;
		Player[] player2 = Main.player;
		foreach (Player player in player2)
		{
			if (player.Distance(npc.Center) < NearestPlayerDist)
			{
				NearestPlayerDist = player.Distance(npc.Center);
				NearestPlayer = player.whoAmI;
			}
		}
		return NearestPlayer;
	}

	public static Vector2 VelocityToPoint(Vector2 A, Vector2 B, float Speed)
	{
		Vector2 Move = B - A;
		return Move * (Speed / (float)Math.Sqrt(Move.X * Move.X + Move.Y * Move.Y));
	}

	public static Vector2 RandomPointInArea(Vector2 A, Vector2 B)
	{
		return new Vector2(Main.rand.Next((int)A.X, (int)B.X) + 1, Main.rand.Next((int)A.Y, (int)B.Y) + 1);
	}

	public static Vector2 RandomPointInArea(Rectangle Area)
	{
		return new Vector2(Main.rand.Next(Area.X, Area.X + Area.Width), Main.rand.Next(Area.Y, Area.Y + Area.Height));
	}

	public static float rotateBetween2Points(Vector2 A, Vector2 B)
	{
		return (float)Math.Atan2(A.Y - B.Y, A.X - B.X);
	}

	public static Vector2 CenterPoint(Vector2 A, Vector2 B)
	{
		return new Vector2((A.X + B.X) / 2f, (A.Y + B.Y) / 2f);
	}

	public static Vector2 PolarPos(Vector2 Point, float Distance, float Angle, int XOffset = 0, int YOffset = 0)
	{
		Vector2 result = default;
		result.X = Distance * (float)Math.Sin(MathHelper.ToDegrees(Angle)) + Point.X + XOffset;
		result.Y = Distance * (float)Math.Cos(MathHelper.ToDegrees(Angle)) + Point.Y + YOffset;
		return result;
	}

	public static Vector2 SmoothFromTo(Vector2 From, Vector2 To, float Smooth = 60f)
	{
		return From + (To - From) / Smooth;
	}
}
