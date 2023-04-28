﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuseByg.model
{
    public class Hus : INotifyPropertyChanged
    {
        private string _husId;
        private string _adresse;
        private HusType _type;
        private int _kvm;
        private int _antalVærelser;
        private Lejemål _lejemål;
        private static int count = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string HusId
        {
            get { return _husId; }
            set { _husId = value; }
        }
        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }

        public HusType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Kvm
        {
            get { return _kvm; }
            set { _kvm = value; }
        }
        public int AntalVærelser
        {
            get { return _antalVærelser; }
            set { _antalVærelser = value; }
        }

        public Lejemål Lejemål
        {
            get { return _lejemål; }
            set { _lejemål = value; }
        }

        public bool LejemålFindes { get; set; }
        public bool LejemålFindesIkke { get; set; }

        public Hus(string adresse, HusType type, int kvm, int antalVærelser)
        {
            count++;
            this.HusId = $"H{count}";
            this.Adresse = adresse;
            this.Type = type;
            this.Kvm = kvm;
            this.AntalVærelser = antalVærelser;
            this.LejemålFindes = false;
            this.LejemålFindesIkke = true;

        }
        public void TilføjLejemål(Lejemål lejemål)
        {
            this.Lejemål = lejemål;
            this.LejemålFindes = true;
            this.LejemålFindesIkke = false;
        }
    }
}
