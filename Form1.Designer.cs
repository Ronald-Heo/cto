namespace _1025
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.input = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_go = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.unitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.linktoDataSet = new _1025.linktoDataSet();
            this.unitTableAdapter = new _1025.linktoDataSetTableAdapters.unitTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linktoDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(831, 425);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 36);
            this.textBox1.TabIndex = 0;
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(931, 369);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(75, 32);
            this.input.TabIndex = 1;
            this.input.Text = "입력";
            this.input.UseVisualStyleBackColor = true;
            this.input.Click += new System.EventHandler(this.input_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(730, 498);
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(276, 25);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(29, 27);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(772, 439);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(888, 197);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(75, 23);
            this.btn_go.TabIndex = 4;
            this.btn_go.Text = "go";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(857, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(188, 23);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // unitBindingSource
            // 
            this.unitBindingSource.DataMember = "unit";
            this.unitBindingSource.DataSource = this.linktoDataSet;
            // 
            // linktoDataSet
            // 
            this.linktoDataSet.DataSetName = "linktoDataSet";
            this.linktoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // unitTableAdapter
            // 
            this.unitTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 543);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_go);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.input);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Query Call";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linktoDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button input;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.ComboBox comboBox1;
        private linktoDataSet linktoDataSet;
        private System.Windows.Forms.BindingSource unitBindingSource;
        private linktoDataSetTableAdapters.unitTableAdapter unitTableAdapter;
    }
}

