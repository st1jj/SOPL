import React, { useState } from "react";
import { motion } from "framer-motion";
import { UserPlus, User, Mail, Lock } from "lucide-react";
import { AuthLayout } from "../../components/Auth/AuthLayout";
import { AlertMessage } from "../../components/Auth/AlertMessage";
import axios from "axios";
import { useNavigate } from "react-router-dom";

export default function Register() {
  const navigate = useNavigate();
  const [form, setForm] = useState({ userName: "", email: "", password: "" });
  const [message, setMessage] = useState("");
  const [status, setStatus] = useState("info");
  const [isLoading, setIsLoading] = useState(false);

  const handleChange = (e) =>
    setForm({ ...form, [e.target.name]: e.target.value });

  const handleSubmit = async (e) => {
    e.preventDefault();
    setIsLoading(true);
    setMessage("");

    try {
      const res = await axios.post("https://localhost:7135/api/Auth/register", form);

      setMessage(res.data.message || "Rejestracja zakończona sukcesem!");
      setStatus("success");
      setTimeout(() => navigate("/login"), 2000);
    } catch (err) {
      if (err.response) {
        const statusCode = err.response.status;
        if (statusCode >= 400 && statusCode < 500) {
          setStatus("error");
          setMessage(err.response.data?.message || "Błąd po stronie klienta (4xx).");
        } else if (statusCode >= 500) {
          setStatus("error");
          setMessage("Błąd po stronie serwera (5xx). Spróbuj ponownie później.");
        } else {
          setStatus("error");
          setMessage("Nieznany błąd.");
        }
      } else if (err.request) {
        setStatus("error");
        setMessage("Brak połączenia z serwerem. Sprawdź czy backend jest uruchomiony.");
      } else {
        setStatus("error");
        setMessage("Błąd aplikacji: " + err.message);
      }
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <AuthLayout
      icon={UserPlus}
      title="Dołącz do nas!"
      subtitle="Utwórz nowe konto"
      gradientFrom="from-green-600"
      gradientTo="to-emerald-600"
    >
      <AlertMessage message={message} status={status} />

      <div className="space-y-5">
        {/* Nazwa użytkownika */}
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-2">
            Nazwa użytkownika
          </label>
          <div className="relative">
            <User className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400 w-5 h-5 pointer-events-none" />
            <input
              type="text"
              name="userName"
              placeholder="Wprowadź nazwę użytkownika"
              value={form.userName}
              onChange={handleChange}
              className="w-full pl-11 pr-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-green-500 focus:border-transparent transition-all outline-none"
            />
          </div>
        </div>

        {/* Email */}
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-2">
            Email
          </label>
          <div className="relative">
            <Mail className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400 w-5 h-5 pointer-events-none" />
            <input
              type="email"
              name="email"
              placeholder="Wprowadź email"
              value={form.email}
              onChange={handleChange}
              className="w-full pl-11 pr-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-green-500 focus:border-transparent transition-all outline-none"
            />
          </div>
        </div>

        {/* Hasło */}
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-2">
            Hasło
          </label>
          <div className="relative">
            <Lock className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400 w-5 h-5 pointer-events-none" />
            <input
              type="password"
              name="password"
              placeholder="Wprowadź hasło"
              value={form.password}
              onChange={handleChange}
              className="w-full pl-11 pr-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-green-500 focus:border-transparent transition-all outline-none"
            />
          </div>
        </div>

        <motion.button
          whileHover={{ scale: 1.02 }}
          whileTap={{ scale: 0.98 }}
          onClick={handleSubmit}
          disabled={isLoading}
          className="w-full bg-gradient-to-r from-green-600 to-emerald-600 text-white py-3 rounded-lg font-semibold shadow-lg hover:shadow-xl transition-all duration-300 disabled:opacity-50 disabled:cursor-not-allowed flex items-center justify-center gap-2"
        >
          {isLoading ? (
            <>
              <div className="w-5 h-5 border-2 border-white border-t-transparent rounded-full animate-spin"></div>
              <span>Rejestracja...</span>
            </>
          ) : (
            <>
              <UserPlus className="w-5 h-5" />
              <span>Zarejestruj się</span>
            </>
          )}
        </motion.button>
      </div>

      <div className="mt-6 text-center text-sm text-gray-600">
        Masz już konto?{" "}
        <button
          onClick={() => navigate("/login")}
          className="text-green-600 hover:text-green-700 font-semibold"
        >
          Zaloguj się
        </button>
      </div>
    </AuthLayout>
  );
}
