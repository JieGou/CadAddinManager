﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using CadAddinManager.ViewModel;

namespace CadAddinManager.View;

/// <summary>
/// Interaction logic for FrmAddInManager.xaml
/// </summary>
public partial class FrmAddInManager : Window
{
    private readonly AddInManagerViewModel viewModel;

    public FrmAddInManager(AddInManagerViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
        viewModel = vm;
        vm.FrmAddInManager = this;
        this.Closing += FrmAddInManager_Closing;
    }

    private void FrmAddInManager_Closing(object sender, CancelEventArgs e)
    {
        viewModel.FrmAddInManager = null;
    }

    private void TbxDescription_OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        if (viewModel.MAddinManagerBase.ActiveCmdItem != null && TabControl.SelectedIndex == 0)
        {
            viewModel.MAddinManagerBase.ActiveCmdItem.Description = TbxDescription.Text;
        }
        viewModel.MAddinManagerBase.AddinManager.SaveToAimIni();
    }
}