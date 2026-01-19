export interface Patient {
  id: number;
  name: string;
  dateOfBirth: string; // ISO format: 'YYYY-MM-DD'
  phone?: string;
  email?: string;
}