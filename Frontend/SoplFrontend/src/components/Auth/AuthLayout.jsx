import React from "react";
import { motion } from "framer-motion";
import { ArrowLeft } from "lucide-react";

export function AuthLayout({ children, icon: Icon, title, subtitle, gradientFrom, gradientTo, onBack }) {
  return (
    <div className="min-h-screen flex items-center justify-center bg-gradient-to-br from-blue-50 via-indigo-50 to-purple-50 p-4">
      <motion.div
        initial={{ opacity: 0, y: 20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.6, ease: "easeOut" }}
        className="w-full max-w-md"
      >
        <div className="absolute top-20 left-20 w-72 h-72 bg-blue-200 rounded-full mix-blend-multiply filter blur-xl opacity-30 animate-pulse"></div>
        <div className="absolute bottom-20 right-20 w-72 h-72 bg-purple-200 rounded-full mix-blend-multiply filter blur-xl opacity-30 animate-pulse" style={{ animationDelay: '1s' }}></div>
        
        <div className="relative bg-white rounded-2xl shadow-2xl overflow-hidden">
          <div className={`bg-gradient-to-r ${gradientFrom} ${gradientTo} p-8 text-white`}>
            {onBack && (
              <button onClick={onBack} className="mb-4 flex items-center gap-2 text-white/80 hover:text-white transition-colors">
                <ArrowLeft className="w-4 h-4" />
                <span className="text-sm">Powrót</span>
              </button>
            )}
            <motion.div
              initial={{ scale: 0 }}
              animate={{ scale: 1 }}
              transition={{ delay: 0.2, type: "spring", stiffness: 200 }}
              className="w-16 h-16 bg-white/20 rounded-full flex items-center justify-center mx-auto mb-4 backdrop-blur-sm"
            >
              <Icon className="w-8 h-8" />
            </motion.div>
            <h1 className="text-3xl font-bold text-center">{title}</h1>
            <p className="text-white/80 text-center mt-2">{subtitle}</p>
          </div>

          <div className="p-8">
            {children}
          </div>
        </div>
      </motion.div>
    </div>
  );
}