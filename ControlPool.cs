using System;
using System.Collections.Generic;
using Guna.UI2.WinForms;

// Token: 0x02000005 RID: 5
public class ControlPool
{
	// Token: 0x0600000A RID: 10 RVA: 0x000020FD File Offset: 0x000002FD
	public ControlPool()
	{
		this.scriptNameButtonPool = new Queue<Guna2Button>();
		this.scriptPictureButtonPool = new Queue<Guna2PictureBox>();
		this.dataHolderPool = new Queue<Guna2Panel>();
	}

	// Token: 0x0600000B RID: 11 RVA: 0x0000659C File Offset: 0x0000479C
	public Guna2Button GetScriptNameButton()
	{
		if (this.scriptNameButtonPool.Count > 0)
		{
			return this.scriptNameButtonPool.Dequeue();
		}
		if (this.scriptNameButtonPool.Count + this.scriptPictureButtonPool.Count + this.dataHolderPool.Count < this.maxPoolSize)
		{
			return new Guna2Button();
		}
		return null;
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000065F8 File Offset: 0x000047F8
	public Guna2PictureBox GetScriptPictureButton()
	{
		if (this.scriptPictureButtonPool.Count > 0)
		{
			return this.scriptPictureButtonPool.Dequeue();
		}
		if (this.scriptNameButtonPool.Count + this.scriptPictureButtonPool.Count + this.dataHolderPool.Count < this.maxPoolSize)
		{
			return new Guna2PictureBox();
		}
		return null;
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00006654 File Offset: 0x00004854
	public Guna2Panel GetDataHolder()
	{
		if (this.dataHolderPool.Count > 0)
		{
			return this.dataHolderPool.Dequeue();
		}
		if (this.scriptNameButtonPool.Count + this.scriptPictureButtonPool.Count + this.dataHolderPool.Count < this.maxPoolSize)
		{
			return new Guna2Panel();
		}
		return null;
	}

	// Token: 0x0600000E RID: 14 RVA: 0x0000212E File Offset: 0x0000032E
	public void ReturnScriptNameButton(Guna2Button scriptNameButton)
	{
		if (scriptNameButton != null)
		{
			scriptNameButton.ResetText();
			this.scriptNameButtonPool.Enqueue(scriptNameButton);
		}
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002145 File Offset: 0x00000345
	public void ReturnScriptPictureButton(Guna2PictureBox scriptPictureButton)
	{
		if (scriptPictureButton != null)
		{
			scriptPictureButton.Image = null;
			this.scriptPictureButtonPool.Enqueue(scriptPictureButton);
		}
	}

	// Token: 0x06000010 RID: 16 RVA: 0x0000215D File Offset: 0x0000035D
	public void ReturnDataHolder(Guna2Panel dataHolder)
	{
		if (dataHolder != null)
		{
			dataHolder.Controls.Clear();
			this.dataHolderPool.Enqueue(dataHolder);
		}
	}

	// Token: 0x04000004 RID: 4
	private readonly Queue<Guna2Button> scriptNameButtonPool;

	// Token: 0x04000005 RID: 5
	private readonly Queue<Guna2PictureBox> scriptPictureButtonPool;

	// Token: 0x04000006 RID: 6
	private readonly Queue<Guna2Panel> dataHolderPool;

	// Token: 0x04000007 RID: 7
	private readonly int maxPoolSize = 20;
}
