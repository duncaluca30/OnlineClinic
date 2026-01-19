import type { Doctor } from './Doctor'
import type { Patient } from './Patient'

export interface User {
  id: number;
  username: string;
  role: string;
  doctor?: Doctor;
  patient?: Patient;
}