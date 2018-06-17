namespace NijiWatcher
{
    partial class NijiWatcher
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NijiWatcher));
            this.niNijiWatcher = new System.Windows.Forms.NotifyIcon(this.components);
            this.nijiTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // niNijiWatcher
            // 
            this.niNijiWatcher.Icon = ((System.Drawing.Icon)(resources.GetObject("niNijiWatcher.Icon")));
            this.niNijiWatcher.Text = "にじうぉっちゃー";
            this.niNijiWatcher.Visible = true;
            // 
            // nijiTimer
            // 
            this.nijiTimer.Enabled = true;
            this.nijiTimer.Interval = 60000;
            this.nijiTimer.Tick += new System.EventHandler(this.nijiTimer_Tick);
            // 
            // NijiWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 189);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "NijiWatcher";
            this.ShowInTaskbar = false;
            this.Text = "にじうぉっちゃー";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.NijiWatcher_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon niNijiWatcher;
        private System.Windows.Forms.Timer nijiTimer;
    }
}

