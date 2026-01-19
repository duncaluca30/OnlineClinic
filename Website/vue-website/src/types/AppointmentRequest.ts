export interface AppointmentRequest {
  doctor_id: number;
  patient_id: number;
  appointmentDate: string; // ISO format: 'YYYY-MM-DDTHH:mm:ss'
  price: number;
}