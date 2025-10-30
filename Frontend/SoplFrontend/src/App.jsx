import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

import { Button, Box } from "@chakra-ui/react";

function App() {
  return (
    <Box
      display="flex"
      justifyContent="center"
      alignItems="center"
      minHeight="100vh"
      bg="gray.50"
    >
      <Button colorScheme="blue" size="lg">
        Naciśnij mnie
      </Button>
    </Box>
  );
}

export default App;

