import React from "react";
import { motion } from "framer-motion";
import { Heart, Stethoscope, Calendar, Clock, Phone, MapPin, Users, Shield, Award } from "lucide-react";
import { useNavigate } from "react-router-dom";

export default function HomePage() {
  const navigate = useNavigate();
  const features = [
    { icon: Calendar, title: "Łatwe Rezerwacje", description: "Umów wizytę online w kilka sekund" },
    { icon: Users, title: "Doświadczeni Lekarze", description: "Zespół wykwalifikowanych specjalistów" },
    { icon: Clock, title: "Elastyczne Godziny", description: "Otwarte od poniedziałku do soboty" },
    { icon: Shield, title: "Pełna Poufność", description: "Twoje dane są bezpieczne z nami" },
  ];

  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-50 via-white to-teal-50">
      {/* Header / Navigation */}
      <nav className="bg-white/80 backdrop-blur-md shadow-sm sticky top-0 z-50">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between items-center h-16">
            <motion.div initial={{ opacity: 0, x: -20 }} animate={{ opacity: 1, x: 0 }} className="flex items-center gap-3">
              <div className="w-10 h-10 bg-gradient-to-br from-teal-500 to-blue-600 rounded-lg flex items-center justify-center">
                <Heart className="w-6 h-6 text-white" />
              </div>
              <div>
                <h1 className="text-xl font-bold text-gray-800">SDOPL</h1>
                <p className="text-xs text-gray-500">Twoje zdrowie, nasza misja</p>
              </div>
            </motion.div>

            <motion.div initial={{ opacity: 0, x: 20 }} animate={{ opacity: 1, x: 0 }} className="flex items-center gap-3">
              <motion.button whileHover={{ scale: 1.05 }} whileTap={{ scale: 0.95 }} onClick={() => navigate("/login")} className="px-5 py-2 text-teal-600 font-medium hover:text-teal-700 transition-colors">
                Zaloguj się
              </motion.button>
              <motion.button whileHover={{ scale: 1.05 }} whileTap={{ scale: 0.95 }} onClick={() => navigate("/register")} className="px-5 py-2 bg-gradient-to-r from-teal-500 to-blue-600 text-white rounded-lg font-medium shadow-md hover:shadow-lg transition-all">
                Zarejestruj się
              </motion.button>
            </motion.div>
          </div>
        </div>
      </nav>

      {/* Hero Section */}
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 pt-20 pb-16">
        <div className="grid lg:grid-cols-2 gap-12 items-center">
          <motion.div initial={{ opacity: 0, y: 20 }} animate={{ opacity: 1, y: 0 }} transition={{ duration: 0.6 }}>
            <div className="inline-block px-4 py-2 bg-teal-50 text-teal-700 rounded-full text-sm font-medium mb-6">
              <div className="flex items-center gap-2">
                <Award className="w-4 h-4" />
                <span>Zaufana przez 10 000 pacjentów</span>
              </div>
            </div>

            <h1 className="text-5xl lg:text-6xl font-bold text-gray-900 mb-6 leading-tight">
              Twoje zdrowie jest{" "}
              <span className="text-transparent bg-clip-text bg-gradient-to-r from-teal-500 to-blue-600">
                naszym priorytetem
              </span>
            </h1>

            <p className="text-xl text-gray-600 mb-8 leading-relaxed">
              Nowoczesna poliklinika oferująca kompleksową opiekę medyczną. Umów wizytę online i zadbaj o swoje zdrowie już dziś.
            </p>

            <div className="flex flex-wrap gap-4 mb-12">
              <motion.button whileHover={{ scale: 1.05 }} whileTap={{ scale: 0.95 }} onClick={() => navigate("/register")} className="px-8 py-4 bg-gradient-to-r from-teal-500 to-blue-600 text-white rounded-xl font-semibold shadow-xl hover:shadow-2xl transition-all flex items-center gap-2">
                <Calendar className="w-5 h-5" />
                Umów wizytę
              </motion.button>
              <motion.button whileHover={{ scale: 1.05 }} whileTap={{ scale: 0.95 }} className="px-8 py-4 bg-white text-gray-700 rounded-xl font-semibold shadow-lg hover:shadow-xl transition-all flex items-center gap-2 border border-gray-200">
                <Phone className="w-5 h-5" />
                Skontaktuj się
              </motion.button>
            </div>

            <div className="grid grid-cols-2 gap-6">
              <div className="flex items-start gap-3">
                <div className="w-10 h-10 bg-teal-100 rounded-lg flex items-center justify-center flex-shrink-0">
                  <Clock className="w-5 h-5 text-teal-600" />
                </div>
                <div>
                  <p className="font-semibold text-gray-800">Pn-Pt: 8:00-20:00</p>
                  <p className="text-sm text-gray-500">Sobota: 9:00-15:00</p>
                </div>
              </div>
              <div className="flex items-start gap-3">
                <div className="w-10 h-10 bg-blue-100 rounded-lg flex items-center justify-center flex-shrink-0">
                  <MapPin className="w-5 h-5 text-blue-600" />
                </div>
                <div>
                  <p className="font-semibold text-gray-800">ul. Dekabrtystow 26/30</p>
                  <p className="text-sm text-gray-500">Częstochowa, 00-001</p>
                </div>
              </div>
            </div>
          </motion.div>

          <motion.div initial={{ opacity: 0, scale: 0.9 }} animate={{ opacity: 1, scale: 1 }} transition={{ duration: 0.8 }} className="relative">
            <motion.div animate={{ y: [0, -20, 0] }} transition={{ duration: 4, repeat: Infinity, ease: "easeInOut" }} className="absolute inset-0 bg-gradient-to-br from-teal-200 to-blue-200 rounded-3xl opacity-20 blur-3xl" />

            <motion.div animate={{ y: [0, -15, 0] }} transition={{ duration: 5, repeat: Infinity, ease: "easeInOut" }} className="relative bg-gradient-to-br from-teal-400 to-blue-500 rounded-3xl p-8 shadow-2xl">
              <div className="bg-white rounded-2xl p-8">
                <Stethoscope className="w-full h-64 text-teal-500" strokeWidth={1} />
              </div>
            </motion.div>
          </motion.div>
        </div>
      </div>

      {/* Features Section */}
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-20">
        <motion.div initial={{ opacity: 0, y: 20 }} whileInView={{ opacity: 1, y: 0 }} viewport={{ once: true }} className="text-center mb-16">
          <h2 className="text-4xl font-bold text-gray-900 mb-4">Dlaczego warto wybrać SDOPL?</h2>
          <h3 className="text-xl text-gray-600 max-w-2xl mb-4">
            Oferujemy najwyższą jakość opieki medycznej z wykorzystaniem nowoczesnych technologii
          </h3>
        </motion.div>

        <div className="grid md:grid-cols-2 lg:grid-cols-4 gap-8">
          {features.map((feature, index) => (
            <motion.div key={index} initial={{ opacity: 0, y: 20 }} whileInView={{ opacity: 1, y: 0 }} viewport={{ once: true }} transition={{ delay: index * 0.1 }} whileHover={{ y: -5 }} className="bg-white rounded-2xl p-6 shadow-lg hover:shadow-xl transition-all">
              <div className="w-14 h-14 bg-gradient-to-br from-teal-100 to-blue-100 rounded-xl flex items-center justify-center mb-4">
                <feature.icon className="w-7 h-7 text-teal-600" />
              </div>
              <h3 className="text-xl font-bold text-gray-800 mb-2">{feature.title}</h3>
              <p className="text-gray-600">{feature.description}</p>
            </motion.div>
          ))}
        </div>
      </div>
    </div>
  );
}
