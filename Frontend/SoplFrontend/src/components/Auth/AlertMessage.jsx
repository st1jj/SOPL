import React from "react";
import { motion } from "framer-motion";
import { AlertCircle, CheckCircle } from "lucide-react";

export function AlertMessage({ message, status }) {
  if (!message) return null;

  return (
    <motion.div
      initial={{ opacity: 0, x: -20 }}
      animate={{ opacity: 1, x: 0 }}
      className={`flex items-center gap-3 p-4 rounded-lg mb-6 ${
        status === "success"
          ? "bg-green-50 text-green-800 border border-green-200"
          : "bg-red-50 text-red-800 border border-red-200"
      }`}
    >
      {status === "success" ? (
        <CheckCircle className="w-5 h-5 flex-shrink-0" />
      ) : (
        <AlertCircle className="w-5 h-5 flex-shrink-0" />
      )}
      <span className="text-sm font-medium">{message}</span>
    </motion.div>
  );
}