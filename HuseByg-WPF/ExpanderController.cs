using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Markup;


namespace HuseByg_WPF
{
    class ExpanderController
    {

        static private string code = $@"
        
        <Expander xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' Margin='0,0,0,10' HorizontalAlignment='Center' Height='auto' VerticalAlignment='Center' Width='612' Background='#eee' Padding='2' BorderBrush='#999' BorderThickness='1'>

                    <Expander.Header >

                        <Grid Height='35'  Width='564'>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width='*' />
                                <ColumnDefinition Width='*' />
                            </Grid.ColumnDefinitions>

                            <StackPanel Orientation='Horizontal' Grid.Column='0'>
                                <TextBlock Text='H1'  VerticalAlignment='Center' FontWeight='Bold' />
                                <TextBlock Text='Søndergade 20, 8000 Aarhus' Margin='5,0,0,0' VerticalAlignment='Center' />
                                <Button Content='✏️' Margin='10,0,0,0' Width='25' Height='25'  Foreground='#000' />
                            </StackPanel>

                            <StackPanel Orientation='Horizontal' Grid.Column='1'>
                                <TextBlock Margin='0,0,10,0' VerticalAlignment='Center'>
                            <TextBlock>
                                York Oxmall <Bold>(Primær)</Bold>, Anita P. Ness
                            </TextBlock>
                        </TextBlock>
                                <Button Content='✏️' Margin='0,0,10,0' Width='25' Height='25'/>
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
                                <Label Grid.Column='0' Content='3' FontWeight='Bold'/>
                            </StackPanel>

                            <StackPanel VerticalAlignment='Top' Orientation='Horizontal' >
                                <Label Grid.Column='0' Content='Størrelse:' />
                                <Label Grid.Column='0' Content='60 m²' FontWeight='Bold'/>
                            </StackPanel>

                            <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                <Label Grid.Column='0' Content='Type:' />
                                <Label Grid.Column='0' Content='Stor' FontWeight='Bold'/>
                            </StackPanel>
                        </StackPanel>

                        <!-- LEJER COLUMN -->


                        <StackPanel Orientation='Vertical'  Grid.Column='1' Margin='0,0,0,10'>

                            <!--- PERSONER -->
                            <StackPanel Orientation='Vertical'>
                                <StackPanel VerticalAlignment='Top' Margin='0,10,0,0' Orientation='Horizontal'  >
                                    <Label Grid.Column='0' Content='York Oxmall' FontWeight='Bold' VerticalAlignment='Center'/>
                                    <Label Grid.Column='0' Content='(Primær)' VerticalAlignment='Center' />
                                </StackPanel>

                                <Border BorderBrush='#000' BorderThickness='1' Width='220' HorizontalAlignment='Left'></Border>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal' >
                                    <Label Grid.Column='0' Content='Mail:' />
                                    <Label Grid.Column='0' Content='york.oxmall@gmail.com' FontWeight='Bold' />
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Tlf.:' />
                                    <Label Grid.Column='0' Content='+45 20304050' FontWeight='Bold'/>
                                </StackPanel>
                            </StackPanel>

                            <StackPanel Orientation='Vertical' Margin='0,10,0,0'>
                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'  >
                                    <Label Grid.Column='0' Content='Anita P. Ness' FontWeight='Bold' VerticalAlignment='Center' />
                                    <Label Grid.Column='0' Content='' VerticalAlignment='Center' />
                                </StackPanel>

                                <Border BorderBrush='#000' BorderThickness='1' Width='220' HorizontalAlignment='Left'></Border>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal' >
                                    <Label Grid.Column='0' Content='Mail:' />
                                    <Label Grid.Column='0' Content='anita.p.ness@gmail.com' FontWeight='Bold' />
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Tlf.:' />
                                    <Label Grid.Column='0' Content='+45 10306020' FontWeight='Bold'/>
                                </StackPanel>
                            </StackPanel>


                            <!-- LEJEMÅL -->
                            <StackPanel Orientation='Vertical' Margin='0,20,0,0'>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal' >
                                    <Label Grid.Column='0' Content='Indflytningsdato:' />
                                    <Label Grid.Column='0' Content='01-02-2020' FontWeight='Bold' />
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Udflytningsdato:' />
                                    <Label Grid.Column='0' Content='01-09-2021' FontWeight='Bold' />
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Indbetalt depositum:' />
                                    <Label Grid.Column='0' Content='21000 kr.' FontWeight='Bold'/>
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Antal hunde:' />
                                    <Label Grid.Column='0' Content='1' FontWeight='Bold'/>
                                </StackPanel>

                                <StackPanel VerticalAlignment='Top' Orientation='Horizontal'>
                                    <Label Grid.Column='0' Content='Antal katte:' />
                                    <Label Grid.Column='0' Content='0' FontWeight='Bold'/>
                                </StackPanel>
                            </StackPanel>

                        </StackPanel>

                    </Grid>
                </Expander>";

        static public void AddExpander(StackPanel element)
        {
            var xaml = (UIElement)XamlReader.Parse(code);
            element.Children.Add(xaml);
        }
        
    }
}
