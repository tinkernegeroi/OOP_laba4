using System.ComponentModel;

namespace OOP_laba4;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button_Back = new System.Windows.Forms.Button();
        button_Exit = new System.Windows.Forms.Button();
        Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        textBox_FactoryObj = new System.Windows.Forms.TextBox();
        button_CreateRndFam = new System.Windows.Forms.Button();
        button_CreatePremFam = new System.Windows.Forms.Button();
        textBox_Flyweight = new System.Windows.Forms.TextBox();
        button_Flyweight = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // button_Back
        // 
        button_Back.Location = new System.Drawing.Point(12, 633);
        button_Back.Name = "button_Back";
        button_Back.Size = new System.Drawing.Size(115, 35);
        button_Back.TabIndex = 0;
        button_Back.Text = "Назад";
        button_Back.UseVisualStyleBackColor = true;
        button_Back.Click += button_Back_Click;
        // 
        // button_Exit
        // 
        button_Exit.Location = new System.Drawing.Point(865, 633);
        button_Exit.Name = "button_Exit";
        button_Exit.Size = new System.Drawing.Size(115, 35);
        button_Exit.TabIndex = 1;
        button_Exit.Text = "Выход";
        button_Exit.UseVisualStyleBackColor = true;
        button_Exit.Click += button_Exit_Click;
        // 
        // Column1
        // 
        Column1.HeaderText = "Индекс (номер аэропорта)";
        Column1.Name = "Column1";
        // 
        // Column2
        // 
        Column2.HeaderText = "Название";
        Column2.Name = "Column2";
        // 
        // Column3
        // 
        Column3.HeaderText = "Местоположение";
        Column3.Name = "Column3";
        // 
        // Column4
        // 
        Column4.HeaderText = "Полетов за день";
        Column4.Name = "Column4";
        // 
        // Column5
        // 
        Column5.HeaderText = "Билетов продано";
        Column5.Name = "Column5";
        // 
        // Column6
        // 
        Column6.HeaderText = "Баланс";
        Column6.Name = "Column6";
        // 
        // Column7
        // 
        Column7.HeaderText = "Рейтинг";
        Column7.Name = "Column7";
        // 
        // Column8
        // 
        Column8.HeaderText = "Количество работников";
        Column8.Name = "Column8";
        // 
        // textBox_FactoryObj
        // 
        textBox_FactoryObj.Location = new System.Drawing.Point(32, 302);
        textBox_FactoryObj.Multiline = true;
        textBox_FactoryObj.Name = "textBox_FactoryObj";
        textBox_FactoryObj.ReadOnly = true;
        textBox_FactoryObj.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        textBox_FactoryObj.Size = new System.Drawing.Size(524, 294);
        textBox_FactoryObj.TabIndex = 12;
        // 
        // button_CreateRndFam
        // 
        button_CreateRndFam.Location = new System.Drawing.Point(698, 343);
        button_CreateRndFam.Name = "button_CreateRndFam";
        button_CreateRndFam.Size = new System.Drawing.Size(161, 59);
        button_CreateRndFam.TabIndex = 13;
        button_CreateRndFam.Text = "Создать рандом объекты";
        button_CreateRndFam.UseVisualStyleBackColor = true;
        button_CreateRndFam.Click += button_CreateRndFam_Click;
        // 
        // button_CreatePremFam
        // 
        button_CreatePremFam.Location = new System.Drawing.Point(698, 498);
        button_CreatePremFam.Name = "button_CreatePremFam";
        button_CreatePremFam.Size = new System.Drawing.Size(161, 59);
        button_CreatePremFam.TabIndex = 14;
        button_CreatePremFam.Text = "Создать премиум объекты";
        button_CreatePremFam.UseVisualStyleBackColor = true;
        button_CreatePremFam.Click += button_CreatePremiumRndFam_Click;
        // 
        // textBox_Flyweight
        // 
        textBox_Flyweight.Location = new System.Drawing.Point(32, 23);
        textBox_Flyweight.Multiline = true;
        textBox_Flyweight.Name = "textBox_Flyweight";
        textBox_Flyweight.ReadOnly = true;
        textBox_Flyweight.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        textBox_Flyweight.Size = new System.Drawing.Size(524, 246);
        textBox_Flyweight.TabIndex = 15;
        // 
        // button_Flyweight
        // 
        button_Flyweight.Location = new System.Drawing.Point(698, 108);
        button_Flyweight.Name = "button_Flyweight";
        button_Flyweight.Size = new System.Drawing.Size(161, 56);
        button_Flyweight.TabIndex = 16;
        button_Flyweight.Text = "Flyweight demo";
        button_Flyweight.UseVisualStyleBackColor = true;
        button_Flyweight.Click += button_Flyweight_Click;
        // 
        // Form2
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(992, 695);
        Controls.Add(button_Flyweight);
        Controls.Add(textBox_Flyweight);
        Controls.Add(button_CreatePremFam);
        Controls.Add(button_CreateRndFam);
        Controls.Add(textBox_FactoryObj);
        Controls.Add(button_Exit);
        Controls.Add(button_Back);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        Location = new System.Drawing.Point(15, 15);
        MaximizeBox = false;
        Text = "OOP3";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button_Flyweight;

    private System.Windows.Forms.TextBox textBox_Flyweight;

    private System.Windows.Forms.Button button_CreateRndFam;
    private System.Windows.Forms.Button button_CreatePremFam;

    private System.Windows.Forms.TextBox textBox_FactoryObj;

    private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column8;

    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;

    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;

    private System.Windows.Forms.DataGridView dataGridView1;

    private System.Windows.Forms.Button button_Back;
    private System.Windows.Forms.Button button_Exit;

    #endregion
}