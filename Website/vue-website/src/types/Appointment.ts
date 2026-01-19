import type { Doctor } from './Doctor'
import type { Patient } from './Patient'

export interface Appointment {
  id: number;
  doctor: Doctor;
  patient: Patient;
  appointmentDate: string; // ISO format: 'YYYY-MM-DDTHH:mm:ss'
  price: number;
}