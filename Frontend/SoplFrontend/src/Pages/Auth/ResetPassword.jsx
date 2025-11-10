import React, { useState, useEffect } from "react";
import { motion } from "framer-motion";
import { Mail, KeyRound, Lock } from "lucide-react";
import { AuthLayout } from "../../components/Auth/AuthLayout";
import { AlertMessage } from "../../components/Auth/AlertMessage";
import { useSearchParams, useNavigate } from "react-router-dom";
import axios from "axios";

export default function ResetPassword() {
  const [searchParams] = useSearchParams();
  const navigate = useNavigate();
  const [form, setForm] = useState({ email: "", token: "", newPassword: "" });
  const [message, setMessage] = useState("");
  const [status, setStatus] = useState("info");
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    const emailParam = searchParams.get("email");
    const tokenParam = searchParams.get("token");
    if (emailParam && tokenParam) {
      
      setForm({
        email: emailParam,
        token: tokenParam,
        newPassword: ""
      });
    }
  }, [searchParams]);

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = async () => {
    if (!form.newPassword) {
      setMessage("Wprowadź nowe hasło.");
      setStatus("error");
      return;
    }

    setIsLoading(true);

    try {
      const API_BASE_URL = import.meta.env.VITE_API_BASE_URL || "https://localhost:7135";

      const payload = {
        Email: form.email,
        Token: form.token,       // токен без decodeURIComponent
        NewPassword: form.newPassword
      };

      console.log("Sending payload:", payload);

      const response = await axios.post(`${API_BASE_URL}/api/Auth/reset-password`, payload);

      setMessage(response.data.message || "Hasło zresetowane pomyślnie.");
      setStatus("success");
      setTimeout(() => navigate("/login"), 2000);
    } catch (error) {
      console.error("Reset password error:", error.response?.data || error);
      setMessage(error.response?.data?.message || "Błąd podczas resetowania hasła.");
      setStatus("error");
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <AuthLayout
      icon={KeyRound}
      title="Resetuj hasło"
      subtitle="Wprowadź nowe hasło"
      gradientFrom="from-purple-600"
      gradientTo="to-pink-600"
      onBack={() => navigate("/forgot-password")}
    >
      {message && <AlertMessage message={message} status={status} />}

      <div className="space-y-5">
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-2">Email</label>
          <div className="relative">
            <Mail className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400 w-5 h-5 pointer-events-none" />
            <input
              type="email"
              name="email"
              value={form.email}
              disabled
              className="w-full pl-11 pr-4 py-3 border border-gray-300 rounded-lg bg-gray-100 cursor-not-allowed"
            />
          </div>
        </div>

        <input type="hidden" name="token" value={form.token} />

        <div>
          <label className="block text-sm font-medium text-gray-700 mb-2">Nowe hasło</label>
          <div className="relative">
            <Lock className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400 w-5 h-5 pointer-events-none" />
            <input
              type="password"
              name="newPassword"
              placeholder="Wprowadź nowe hasło"
              value={form.newPassword}
              onChange={handleChange}
              className="w-full pl-11 pr-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-purple-500 focus:border-transparent transition-all outline-none"
            />
          </div>
        </div>

        <motion.button
          whileHover={{ scale: 1.02 }}
          whileTap={{ scale: 0.98 }}
          onClick={handleSubmit}
          disabled={isLoading}
          className="w-full bg-gradient-to-r from-purple-600 to-pink-600 text-white py-3 rounded-lg font-semibold shadow-lg hover:shadow-xl transition-all duration-300 disabled:opacity-50 disabled:cursor-not-allowed flex items-center justify-center gap-2"
        >
          {isLoading ? (
            <>
              <div className="w-5 h-5 border-2 border-white border-t-transparent rounded-full animate-spin"></div>
              <span>Resetowanie...</span>
            </>
          ) : (
            <>
              <KeyRound className="w-5 h-5" />
              <span>Zresetuj hasło</span>
            </>
          )}
        </motion.button>
      </div>

      <div className="mt-6 text-center text-sm text-gray-600">
        Powrót do{" "}
        <button
          onClick={() => navigate("/login")}
          className="text-purple-600 hover:text-purple-700 font-semibold"
        >
          Logowania
        </button>
      </div>

      <div className="mt-4 text-center">
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
