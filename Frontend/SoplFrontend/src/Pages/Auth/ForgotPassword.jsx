import React, { useState } from "react";
import { motion } from "framer-motion";
import { Mail } from "lucide-react";
import { AuthLayout } from "../../components/Auth/AuthLayout";
import { AlertMessage } from "../../components/Auth/AlertMessage";
import axios from "axios";
import { useNavigate } from "react-router-dom";

export default function ForgotPassword() {
  const navigate = useNavigate();
  const [email, setEmail] = useState("");
  const [message, setMessage] = useState("");
  const [status, setStatus] = useState("info");
  const [isLoading, setIsLoading] = useState(false);

  const handleSubmit = async () => {
    if (!email) {
      setMessage("Podaj adres email.");
      setStatus("error");
      return;
    }

    setIsLoading(true);

    try {
      const API_BASE_URL = import.meta.env.VITE_API_BASE_URL || "https://localhost:7135";

      const response = await axios.post(`${API_BASE_URL}/api/Auth/forgot-password`, { email });

      setMessage(
        typeof response.data?.message === "string"
          ? response.data.message
          : "Link resetujący został wysłany."
      );
      setStatus("success");
    } catch (error) {
      console.error("Forgot password error:", error);

      const errorMessage =
        typeof error.response?.data?.message === "string"
          ? error.response.data.message
          : "Nie udało się wysłać wiadomości e-mail.";

      setMessage(errorMessage);
      setStatus("error");
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <AuthLayout
      icon={Mail}
      title="Zapomniałeś hasła?"
      subtitle="Wyślemy link resetujący na Twój email"
      gradientFrom="from-orange-600"
      gradientTo="to-amber-600"
      onBack={() => navigate("/login")}
    >
      {message && <AlertMessage message={message} status={status} />}

      <div className="space-y-5">
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-2">
            Adres email
          </label>
          <div className="relative">
            <Mail className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400 w-5 h-5 pointer-events-none" />
            <input
              type="email"
              placeholder="Wprowadź swój email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              className="w-full pl-11 pr-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-orange-500 focus:border-transparent transition-all outline-none"
            />
          </div>
        </div>

        <motion.button
          whileHover={{ scale: 1.02 }}
          whileTap={{ scale: 0.98 }}
          onClick={handleSubmit}
          disabled={isLoading}
          className="w-full bg-gradient-to-r from-orange-600 to-amber-600 text-white py-3 rounded-lg font-semibold shadow-lg hover:shadow-xl transition-all duration-300 disabled:opacity-50 disabled:cursor-not-allowed flex items-center justify-center gap-2"
        >
          {isLoading ? (
            <>
              <div className="w-5 h-5 border-2 border-white border-t-transparent rounded-full animate-spin"></div>
              <span>Wysyłanie...</span>
            </>
          ) : (
            <>
              <Mail className="w-5 h-5" />
              <span>Wyślij link resetujący</span>
            </>
          )}
        </motion.button>
      </div>

      <div className="mt-6 text-center">
        <button
          onClick={() => navigate("/")}
          className="text-sm text-gray-500 hover:text-gray-700"
        >
          ← Powrót do strony głównej
        </button>
      </div>
    </AuthLayout>
  );
}
