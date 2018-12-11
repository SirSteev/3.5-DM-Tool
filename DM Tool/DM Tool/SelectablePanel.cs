﻿using System;
using System.Drawing;
using System.Windows.Forms;

class SelectablePanel : Panel
{
    // used with map to make it scrollable

    public SelectablePanel()
    {
        this.SetStyle(ControlStyles.Selectable, true);
        this.TabStop = true;
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        this.Focus();
        base.OnMouseDown(e);
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        if (this.VScroll && (Control.ModifierKeys & Keys.Control) == Keys.Control)
        {
            this.VScroll = false;
            base.OnMouseWheel(e);
            this.VScroll = true;
        }
        else
        {
            base.OnMouseWheel(e);
        }
    }

    protected override bool IsInputKey(Keys keyData)
    {
        if (keyData == Keys.Up || keyData == Keys.Down) return true;
        if (keyData == Keys.Left || keyData == Keys.Right) return true;
        return base.IsInputKey(keyData);
    }
    protected override void OnEnter(EventArgs e)
    {
        this.Invalidate();
        base.OnEnter(e);
    }
    protected override void OnLeave(EventArgs e)
    {
        this.Invalidate();
        base.OnLeave(e);
    }
    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);
        if (this.Focused)
        {
            var rc = this.ClientRectangle;
            rc.Inflate(-2, -2);
            ControlPaint.DrawFocusRectangle(pe.Graphics, rc);
        }
    }
}