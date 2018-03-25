﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GATARI.HoloLensGPS {
    public static class GPSUtility {
        static double GRS80_A = 6378137.000;
        static double GRS80_E2 = 0.00669438002301188;
        static double GRS80_MNUM = 6335439.32708317;

        public static double HubenyDistance(double[] from_, double[] to_, double a, double e2, double mnum) {
            double my = Deg2Rad((from_[0] + to_[0]) / 2.0);
            double dy = Deg2Rad(from_[0] - to_[0]);
            double dx = Deg2Rad(from_[1] - to_[1]);

            double sin = Math.Sin(my);
            double w = Math.Sqrt(1.0 - e2 * sin * sin);
            double m = mnum / (w * w * w);
            double n = a / w;

            double dym = dy * m;
            double dxncos = dx * n * Math.Cos(my);

            return Math.Sqrt(dym * dym + dxncos * dxncos);
        }

        public static double HubenyDistance(double[] from_, double[] to_) {
            return HubenyDistance(from_, to_, GRS80_A, GRS80_E2, GRS80_MNUM);
        }

        public static double Deg2Rad(double deg) {
            return deg * Math.PI / 180.0;
        }
    }
}

