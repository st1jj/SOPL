import React, { useState } from "react";
import { motion } from "framer-motion";
import { LogIn, User, Lock } from "lucide-react";
import { AuthLayout } from "../../components/Auth/AuthLayout";
import { AlertMessage } from "../../components/Auth/AlertMessage";
import axios from "axios";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const navigate = useNavigate();
  const [form, setForm] = useState({ userName: "", password: "" });
  const [message, setMessage] = useState("");
  const [status, setStatus] = useState("info");
  const [isLoading, setIsLoading] = useState(false);

  const handleChange = (e) =>
    setForm({ ...form, [e.target.name]: e.target.value });

  const handleSubmit = async () => {
    setIsLoading(true);
    setMessage("");
    try {
      const res = await axios.post("https://localhost:7135/api/Auth/login", form);

      setStatus("success");
      setMessage(res.data.message || "Logowanie zakończone sukcesem!");

      localStorage.setItem("token", res.data.token);
      localStorage.setItem("userName", res.data.userName);

      setTimeout(() => navigate("/"), 2000);
    } catch (err) {
      if (err.response) {
        const msg = err.response.data?.message || "Błąd logowania.";
        setStatus("error");
        setMessage(msg);
      } else {
        setStatus("error");
        setMessage("Brak połączenia z serwerem. Upewnij się, że backend działa.");
      }
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <AuthLayout
      icon={LogIn}
      title="Witamy ponownie!"
      subtitle="Zaloguj się do swojego konta"
      gradientFrom="from-blue-600"
      gradientTo="to-indigo-600"
    >
      <AlertMessage message={message} status={status} />

      <div className="space-y-5">
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-2">Nazwa użytkownika</label>
          <div className="relative">
            <User className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400 w-5 h-5 pointer-events-none" />
            <input
              type="text"
              name="userName"
              placeholder="Wprowadź nazwę użytkownika"
              value={form.userName}
              onChange={handleChange}
              className="w-full pl-11 pr-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent transition-all outline-none"
            />
          </div>
        </div>

        <div>
          <label className="block text-sm font-medium text-gray-700 mb-2">Hasło</label>
          <div className="relative">
            <Lock className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400 w-5 h-5 pointer-events-none" />
            <input
              type="password"
              name="password"
              placeholder="Wprowadź hasło"
              value={form.password}
              onChange={handleChange}
              className="w-full pl-11 pr-4 py-3 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-transparent transition-all outline-none"
            />
          </div>
        </div>

        <motion.button
          whileHover={{ scale: 1.02 }}
          whileTap={{ scale: 0.98 }}
          onClick={handleSubmit}
          disabled={isLoading}
          className="w-full bg-gradient-to-r from-blue-600 to-indigo-600 text-white py-3 rounded-lg font-semibold shadow-lg hover:shadow-xl transition-all duration-300 disabled:opacity-50 disabled:cursor-not-allowed flex items-center justify-center gap-2"
        >
          {isLoading ? (
            <>
              <div className="w-5 h-5 border-2 border-white border-t-transparent rounded-full animate-spin"></div>
              <span>Logowanie...</span>
            </>
          ) : (
            <>
              <LogIn className="w-5 h-5" />
              <span>Zaloguj się</span>
            </>
          )}
        </motion.button>
      </div>

      <div className="mt-6 text-center text-sm text-gray-600">
        Nie masz konta?{" "}
        <button onClick={() => navigate("/register")} className="text-blue-600 hover:text-blue-700 font-semibold">
          Zarejestruj się
        </button>
      </div>
      <div className="mt-6 text-center text-sm text-gray-600">
        Zapomniałeś hasło?{" "}
        <button onClick={() => navigate("/forgot-password")} className="text-blue-600 hover:text-blue-700 font-semibold">
          Zresetuj hasło
        </button>
      </div>
    </AuthLayout>
  );
}
