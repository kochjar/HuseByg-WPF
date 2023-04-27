using HuseByg.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Markup;


namespace HuseByg_WPF
{
    class ExpanderController
    {
        static public void AddExpander(StackPanel element, Lejemål lejemål, Hus hus)
        {
            

            string code;
            if (lejemål == null)
            {
                code = $@"

                <Expander xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' Margin='0,0,0,10' HorizontalAlignment='Center' Height='auto' VerticalAlignment='Center' Width='612' Background='#eee' Padding='2' BorderBrush='#999' BorderThickness='1'>

                    <Expander.Header >

                        <Grid Height='35'  Width='564'>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width='*' />
                                <ColumnDefinition Width='*' />
                            </Grid.ColumnDefinitions>

                            <DockPanel Grid.Column='0'>
                                <Button Content='✏️' Margin='0,0,10,0' Width='25' Height='25'  Foreground='#000' DockPanel.Dock='Right' Tag='{hus}'  />
                                <StackPanel Orientation='Horizontal' DockPanel.Dock='Left'>
                                    <TextBlock Text='{hus.HusId}'  VerticalAlignment='Center' FontWeight='Bold' />
                                    <TextBlock Text='{hus.Adresse}' Margin='5,0,0,0' VerticalAlignment='Center' />
                                </StackPanel>
                            </DockPanel>
                            
                            
                            <StackPanel Orientation='Horizontal'  Grid.Column='1'>
                                <Button Content='Tilføj lejere 🧑' Margin='0,0,10,0' Height='25' Width='90'/>
                            </StackPanel>
                            
                        </Grid>

                    </Expander.Header>
                    <Grid Background='#fff' Width='610' Height='auto'>

                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width='*' />
                            <ColumnDefinition Width='*' />
                        </Grid.ColumnDefinitions>

                        <!-- HUS COLUMN -->
                        <StackPanel Orientation='Vertical'  Grid.Column='0' Margin='10,10,0,0'>
                            <StackPanel VerticalAlignment='Top' Orientation='Horizontal'  >
                                <Label Grid.Column='0' Content='Detaljer' FontWeight='Bold' VerticalAlignment='Center' />
                            </StackPanel>

                            <Border BorderBrush='#000' BorderThickness='1' Width='220' HorizontalAlignment='Left'></Border>

                            <StackPanel VerticalAlignment='Top' Orientation='Horizontal'  >
                                <Label Grid.Column='0' Content='Antal værelser:' />
                                <Label Grid.Column='0' Content='{hus.AntalVærelser}' FontWeight='Bold'/>
                            </StackPanel>

                            <StackPanel VerticalAlignment='Top' Orientation='Horizontal' >
                                <Label Grid.Column='0' Content='Størrelse:' />
                                <Label Grid.Column='0' Content='{hus.Kvm} m²' FontWeight='Bold'/>
                            </StackPanel>

                            <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                <Label Grid.Column='0' Content='Type:' />
                                <Label Grid.Column='0' Content='{hus.Type}' FontWeight='Bold'/>
                            </StackPanel>
                        </StackPanel>

                        <!-- TOM LEJER COLUMN -->

                    </Grid>
                </Expander>";
            }
            else if (lejemål.Lejere.Count == 1)
            {
                code = $@"

            <Expander xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' Margin='0,0,0,10' HorizontalAlignment='Center' Height='auto' VerticalAlignment='Center' Width='612' Background='#eee' Padding='2' BorderBrush='#999' BorderThickness='1'>

                    <Expander.Header >

                        <Grid Height='35'  Width='564'>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width='*' />
                                <ColumnDefinition Width='*' />
                            </Grid.ColumnDefinitions>

                            <DockPanel Grid.Column='0'>
                                <Button Content='✏️' Margin='0,0,10,0' Width='25' Height='25'  Foreground='#000' DockPanel.Dock='Right' />
                                <StackPanel Orientation='Horizontal' DockPanel.Dock='Left'>
                                    <TextBlock Text='{hus.HusId}'  VerticalAlignment='Center' FontWeight='Bold' />
                                    <TextBlock Text='{hus.Adresse}' Margin='5,0,0,0' VerticalAlignment='Center' />
                                </StackPanel>
                            </DockPanel>

                            <DockPanel Grid.Column='1'>
                                <Button Content='✏️' Margin='0,0,0,0' Width='25' Height='25' DockPanel.Dock='Right'/>
                                <StackPanel Orientation='Horizontal' Grid.Column='1' DockPanel.Dock='Left'>
                                    <TextBlock Margin='0,0,10,0' VerticalAlignment='Center'>
                                        <TextBlock>
                                            {lejemål.Lejere[0].navn} <Bold>(Primær)</Bold>
                                        </TextBlock>
                                    </TextBlock>
                                </StackPanel>
                            </DockPanel>
                        </Grid>

                    </Expander.Header>
                    <Grid Background='#fff' Width='610' Height='auto'>

                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width='*' />
                            <ColumnDefinition Width='*' />
                        </Grid.ColumnDefinitions>

                        <!-- HUS COLUMN -->
                        <StackPanel Orientation='Vertical'  Grid.Column='0' Margin='10,10,0,0'>
                            <StackPanel VerticalAlignment='Top' Orientation='Horizontal'  >
                                <Label Grid.Column='0' Content='Detaljer' FontWeight='Bold' VerticalAlignment='Center' />
                            </StackPanel>

                            <Border BorderBrush='#000' BorderThickness='1' Width='220' HorizontalAlignment='Left'></Border>

                            <StackPanel VerticalAlignment='Top' Orientation='Horizontal'  >
                                <Label Grid.Column='0' Content='Antal værelser:' />
                                <Label Grid.Column='0' Content='{hus.AntalVærelser}' FontWeight='Bold'/>
                            </StackPanel>

                            <StackPanel VerticalAlignment='Top' Orientation='Horizontal' >
                                <Label Grid.Column='0' Content='Størrelse:' />
                                <Label Grid.Column='0' Content='{hus.Kvm} m²' FontWeight='Bold'/>
                            </StackPanel>

                            <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                <Label Grid.Column='0' Content='Type:' />
                                <Label Grid.Column='0' Content='{hus.Type}' FontWeight='Bold'/>
                            </StackPanel>
                        </StackPanel>

                        <!-- LEJER COLUMN -->


                        <StackPanel Orientation='Vertical'  Grid.Column='1' Margin='0,0,0,10'>

                            <!--- PERSONER -->
                            <StackPanel Orientation='Vertical'>
                          

                                <Border BorderBrush='#000' BorderThickness='1' Width='220' HorizontalAlignment='Left'></Border>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal' >
                                    <Label Grid.Column='0' Content='Mail:' />
                                    <Label Grid.Column='0' Content='{lejemål.Lejere[0].mail}' FontWeight='Bold' />
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Tlf.:' />
                                    <Label Grid.Column='0' Content='+45 {lejemål.Lejere[0].tlf_nr}' FontWeight='Bold'/>
                                </StackPanel>
                            </StackPanel>


                            <!-- LEJEMÅL -->
                            <StackPanel Orientation='Vertical' Margin='0,20,0,0'>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal' >
                                    <Label Grid.Column='0' Content='Indflytningsdato:' />
                                    <Label Grid.Column='0' Content='{lejemål.Indflytningsdato.ToString("dd-MM-yyyy")}' FontWeight='Bold' />
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Fraflytningsdato:' />
                                    <Label Grid.Column='0' Content= '{lejemål.Fraflytningsdato.ToString("dd-MM-yyyy")}' FontWeight ='Bold' />
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Indbetalt depositum:' />
                                    <Label Grid.Column='0' Content='{lejemål.IndbetaltDepositum.ToString("0,0")} kr.' FontWeight='Bold'/>
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Antal hunde:' />
                                    <Label Grid.Column='0' Content='{lejemål.AntalHunde}' FontWeight='Bold'/>
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Antal katte:' />
                                    <Label Grid.Column='0' Content='{lejemål.AntalKatte}' FontWeight='Bold'/>
                                </StackPanel>
                            </StackPanel>

                        </StackPanel>

                    </Grid>
                </Expander>";

            } else
            {
                code = $@"

            <Expander xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' Margin='0,0,0,10' HorizontalAlignment='Center' Height='auto' VerticalAlignment='Center' Width='612' Background='#eee' Padding='2' BorderBrush='#999' BorderThickness='1'>

                    <Expander.Header >

                        <Grid Height='35'  Width='564'>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width='*' />
                                <ColumnDefinition Width='*' />
                            </Grid.ColumnDefinitions>

                            <DockPanel Grid.Column='0'>
                                <Button Content='✏️' Margin='0,0,10,0' Width='25' Height='25'  Foreground='#000' DockPanel.Dock='Right' />
                                <StackPanel Orientation='Horizontal' DockPanel.Dock='Left'>
                                    <TextBlock Text='{hus.HusId}'  VerticalAlignment='Center' FontWeight='Bold' />
                                    <TextBlock Text='{hus.Adresse}' Margin='5,0,0,0' VerticalAlignment='Center' />
                                </StackPanel>
                            </DockPanel>

                            <DockPanel Grid.Column='1'>
                                <Button Content='✏️' Margin='0,0,0,0' Width='25' Height='25' DockPanel.Dock='Right'/>
                                <StackPanel Orientation='Horizontal' Grid.Column='1' DockPanel.Dock='Left'>
                                    <TextBlock Margin='0,0,10,0' VerticalAlignment='Center'>
                                        <TextBlock>
                                            {lejemål.Lejere[0].navn} <Bold>(Primær)</Bold>, {lejemål.Lejere[1].navn}
                                        </TextBlock>
                                    </TextBlock>
                                </StackPanel>
                            </DockPanel>
                        </Grid>

                    </Expander.Header>
                    <Grid Background='#fff' Width='610' Height='auto'>

                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width='*' />
                            <ColumnDefinition Width='*' />
                        </Grid.ColumnDefinitions>

                        <!-- HUS COLUMN -->
                        <StackPanel Orientation='Vertical'  Grid.Column='0' Margin='10,10,0,0'>
                            <StackPanel VerticalAlignment='Top' Orientation='Horizontal'  >
                                <Label Grid.Column='0' Content='Detaljer' FontWeight='Bold' VerticalAlignment='Center' />
                            </StackPanel>

                            <Border BorderBrush='#000' BorderThickness='1' Width='220' HorizontalAlignment='Left'></Border>

                            <StackPanel VerticalAlignment='Top' Orientation='Horizontal'  >
                                <Label Grid.Column='0' Content='Antal værelser:' />
                                <Label Grid.Column='0' Content='{hus.AntalVærelser}' FontWeight='Bold'/>
                            </StackPanel>

                            <StackPanel VerticalAlignment='Top' Orientation='Horizontal' >
                                <Label Grid.Column='0' Content='Størrelse:' />
                                <Label Grid.Column='0' Content='{hus.Kvm} m²' FontWeight='Bold'/>
                            </StackPanel>

                            <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                <Label Grid.Column='0' Content='Type:' />
                                <Label Grid.Column='0' Content='{hus.Type}' FontWeight='Bold'/>
                            </StackPanel>
                        </StackPanel>

                        <!-- LEJER COLUMN -->


                        <StackPanel Orientation='Vertical'  Grid.Column='1' Margin='0,0,0,10'>

                            <!--- PERSONER -->
                            <StackPanel Orientation='Vertical'>
                                <StackPanel VerticalAlignment='Top' Margin='0,10,0,0' Orientation='Horizontal'  >
                                    <Label Grid.Column='0' Content='{lejemål.Lejere[0].navn}' FontWeight='Bold' VerticalAlignment='Center'/>
                                    <Label Grid.Column='0' Content='(Primær)' VerticalAlignment='Center' />
                                </StackPanel>

                                <Border BorderBrush='#000' BorderThickness='1' Width='220' HorizontalAlignment='Left'></Border>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal' >
                                    <Label Grid.Column='0' Content='Mail:' />
                                    <Label Grid.Column='0' Content='{lejemål.Lejere[0].mail}' FontWeight='Bold' />
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Tlf.:' />
                                    <Label Grid.Column='0' Content='+45 {lejemål.Lejere[0].tlf_nr}' FontWeight='Bold'/>
                                </StackPanel>
                            </StackPanel>

                            <StackPanel Orientation='Vertical' Margin='0,10,0,0'>
                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'  >
                                    <Label Grid.Column='0' Content='{lejemål.Lejere[1].navn}' FontWeight='Bold' VerticalAlignment='Center' />
                                    <Label Grid.Column='0' Content='' VerticalAlignment='Center' />
                                </StackPanel>

                                <Border BorderBrush='#000' BorderThickness='1' Width='220' HorizontalAlignment='Left'></Border>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal' >
                                    <Label Grid.Column='0' Content='Mail:' />
                                    <Label Grid.Column='0' Content='{lejemål.Lejere[1].mail}' FontWeight='Bold' />
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Tlf.:' />
                                    <Label Grid.Column='0' Content='+45 {lejemål.Lejere[1].tlf_nr}' FontWeight='Bold'/>
                                </StackPanel>
                            </StackPanel>


                            <!-- LEJEMÅL -->
                            <StackPanel Orientation='Vertical' Margin='0,20,0,0'>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal' >
                                    <Label Grid.Column='0' Content='Indflytningsdato:' />
                                    <Label Grid.Column='0' Content='{lejemål.Indflytningsdato.ToString("dd-MM-yyyy")}' FontWeight='Bold' />
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Fraflytningsdato:' />
                                    <Label Grid.Column='0' Content= '{lejemål.Fraflytningsdato.ToString("dd-MM-yyyy")}' FontWeight ='Bold' />
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Indbetalt depositum:' />
                                    <Label Grid.Column='0' Content='{lejemål.IndbetaltDepositum.ToString("0,0")} kr.' FontWeight='Bold'/>
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Antal hunde:' />
                                    <Label Grid.Column='0' Content='{lejemål.AntalHunde}' FontWeight='Bold'/>
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Antal katte:' />
                                    <Label Grid.Column='0' Content='{lejemål.AntalKatte}' FontWeight='Bold'/>
                                </StackPanel>
                            </StackPanel>

                        </StackPanel>

                    </Grid>
                </Expander>";
            }

            
            var xaml = (UIElement)XamlReader.Parse(code);
            element.Children.Add(xaml);
        }
        
    }
}
